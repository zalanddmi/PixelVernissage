using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using PVS.Server.Exceptions;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PVS.Server.Middlewares
{
    public class GlobalExceptionHandler(IHostEnvironment env) : IExceptionHandler
    {
        private static readonly JsonSerializerOptions SerializerOptions = new(JsonSerializerDefaults.Web)
        {
            Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
        };

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            ProblemDetails problemDetails = CreateProblemDetails(httpContext, exception);
            string json = JsonSerializer.Serialize(problemDetails, SerializerOptions);

            const string contentType = "application/problem+json";
            httpContext.Response.ContentType = contentType;
            await httpContext.Response.WriteAsync(json, cancellationToken);

            return true;
        }

        private ProblemDetails CreateProblemDetails(in HttpContext context, in Exception exception)
        {
            HttpStatusCode statusCode = exception switch
            {
                BadRequestException => HttpStatusCode.BadRequest,
                NotFoundException => HttpStatusCode.NotFound,
                _ => HttpStatusCode.InternalServerError
            };
            string reasonPhrase = ReasonPhrases.GetReasonPhrase((int)statusCode);
            if (string.IsNullOrEmpty(reasonPhrase))
            {
                reasonPhrase = "При выполнении запроса произошло необработанное исключение.";
            }

            ProblemDetails problemDetails = new ()
            {
                Status = (int)statusCode,
                Title = reasonPhrase,
                Detail = exception.Message
            };

            if (!env.IsDevelopment())
            {
                return problemDetails;
            }

            problemDetails.Extensions["traceId"] = context.TraceIdentifier;
            problemDetails.Extensions["data"] = exception.Data;

            return problemDetails;
        }
    }
}
