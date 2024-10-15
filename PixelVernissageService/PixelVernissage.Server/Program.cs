using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using PVS.Domain.Interfaces.Services;
using PVS.Infrastructure.Context;
using PVS.Server.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("secrets.json", false, false)
        .AddJsonFile("appsettings.json", false, false)
        .AddJsonFile($@"appsettings.{builder.Environment.EnvironmentName}.json", false, false)
        .AddCommandLine(args)
        .AddEnvironmentVariables()
        .AddUserSecrets(typeof(Program).Assembly);

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
    });
builder.Services.AddAuthorization();

builder.Services.AddHttpContextAccessor();

var connectionString = builder.Configuration.GetConnectionString("Postgres");

builder.Services.AddDbContext<PvsContext>(options =>
{
    options.UseNpgsql(connectionString);
});

builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/", () =>
{
    return Results.Text(content: "<a href='/login'> ����� </a>", contentType: "text/html", contentEncoding: System.Text.Encoding.UTF8);
});

app.MapGet("/login", () =>
{
    return Results.Text(content: "<p>���� �����������</p> <br> <a href='/logout'> ����� </a>", contentType: "text/html", contentEncoding: System.Text.Encoding.UTF8);
}).RequireAuthorization();

app.MapGet("/logout", (HttpContext context) =>
{
    return new SignOutResult(
            [
                OpenIdConnectDefaults.AuthenticationScheme,
                CookieAuthenticationDefaults.AuthenticationScheme
            ]);
});

app.MapGet("/user-info", (HttpContext context) =>
{
    return context.User.FindFirst("preferred_username").Value;
});

app.MapGet("/ping-database", () =>
{
    using (var conn = new NpgsqlConnection(connectionString))
    {
        Console.WriteLine("Opening connection");
        conn.Open();
        using (var command = new NpgsqlCommand("SELECT id, data FROM ping", conn))
        {
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"{reader.GetValue(0)}, {reader.GetValue(1)}");
            }
            reader.Close();
        }
    }
    return "����������� � �� �������";
});

app.Run();
