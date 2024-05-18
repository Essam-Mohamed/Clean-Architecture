using System.Net;
using System.Text.Json;

namespace BuberDinner.Api.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExcptionAsync(context, ex);
            }
        }

        private static Task HandleExcptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError; //500 if unexpected
            var result = JsonSerializer.Serialize(new { error = exception.Message, errorCode = code });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
