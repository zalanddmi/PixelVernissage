using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Minio;
using Npgsql;
using PVS.Application.Profiles;
using PVS.Application.Requests.Account;
using PVS.Domain.Interfaces.Repositories;
using PVS.Domain.Interfaces.Services;
using PVS.Infrastructure.Context;
using PVS.Infrastructure.Repositories;
using PVS.Server.Middlewares;
using PVS.Server.Services;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("secrets.json", false, false)
        .AddJsonFile("appsettings.json", false, false)
        .AddJsonFile($@"appsettings.{builder.Environment.EnvironmentName}.json", false, false)
        .AddCommandLine(args)
        .AddEnvironmentVariables()
        .AddUserSecrets(typeof(Program).Assembly);

builder.Services.AddCors(options =>
{
    options.AddPolicy(
      "Development",
      builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
    );
});
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer().AddSwaggerGen();
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
})
    .AddCookie(options => {

    })
    .AddOpenIdConnect(options =>
    {
        options.Authority = builder.Configuration["Keycloak:Authority"];
        options.ClientId = builder.Configuration["Keycloak:ClientId"];
        options.ClientSecret = builder.Configuration["Keycloak:ClientSecret"];
        options.ResponseType = "code";
        options.SaveTokens = true;
        options.SignedOutRedirectUri = "/";
        options.Events = new OpenIdConnectEvents
        {
            OnTokenValidated = async ctx =>
            {
                string userId = ctx.Principal.FindFirstValue(ClaimTypes.NameIdentifier);
                string username = ctx.Principal.FindFirstValue("preferred_username");
                string? fio = ctx.Principal.FindFirstValue("name");
                string? email = ctx.Principal.FindFirstValue(ClaimTypes.Email);
                var mediator = ctx.HttpContext.RequestServices.GetRequiredService<IMediator>();
                await mediator.Send(new AuthorizeRequest(userId, username, fio, email));
            }
        };
    });
builder.Services.AddAuthorization();

builder.Services.AddMinio(configureClient => configureClient
            .WithEndpoint(builder.Configuration["Minio:Endpoint"])
            .WithCredentials(builder.Configuration["Minio:AccessKey"], builder.Configuration["Minio:SecretKey"])
            .Build());

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
builder.Services.AddAutoMapper(typeof(GenreProfile));
builder.Services.AddHttpContextAccessor();

var connectionString = builder.Configuration.GetConnectionString("Postgres");

builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddDbContext<PvsContext>(options =>
{
    var connectionStringBuilder = new NpgsqlConnectionStringBuilder(connectionString);
    var searchPaths = connectionStringBuilder.SearchPath?.Split(',');

    options.UseNpgsql(connectionString, o =>
    {
        if (searchPaths is { Length: > 0 })
        {
            var mainSchema = searchPaths[0];
            o.MigrationsHistoryTable(HistoryRepository.DefaultTableName, mainSchema);
        }
    });
});

var app = builder.Build();

app.UseCors("Development");
app.UseExceptionHandler();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/login", () =>
{
    return Results.Text(content: "<a href='/login-success'> Войти </a>", contentType: "text/html", contentEncoding: System.Text.Encoding.UTF8);
});

app.MapGet("/login-success", () =>
{
    return Results.Text(content: "<p>Вход осуществлен</p> <br> <a href='/logout'> Выйти </a>", contentType: "text/html", contentEncoding: System.Text.Encoding.UTF8);
}).RequireAuthorization();

app.MapGet("/logout", (HttpContext context) =>
{
    return new SignOutResult(
            [
                OpenIdConnectDefaults.AuthenticationScheme,
                CookieAuthenticationDefaults.AuthenticationScheme
            ]);
});

app.Run();
