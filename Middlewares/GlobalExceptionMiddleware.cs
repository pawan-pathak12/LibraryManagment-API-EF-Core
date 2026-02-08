using Microsoft.Data.SqlClient;

namespace Library_Management_API.Middlewares
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
        {
            this._next = next;
            this._logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);  // continue pipeline
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Unhandled exception occured");
                await HandleExceptionAsync(context, ex);
            }

        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            var statusCode = StatusCodes.Status500InternalServerError;
            var message = "something went wrong";


            if (exception is KeyNotFoundException)
            {
                statusCode = StatusCodes.Status404NotFound;
                message = exception.Message;
            }
            else if (exception is ArgumentException)
            {
                statusCode = StatusCodes.Status400BadRequest;
                message = exception.Message;
            }
            else if (exception is SqlException)
            {
                statusCode = StatusCodes.Status500InternalServerError;
                message = "internal server error ";
            }

            context.Response.StatusCode = statusCode;

            var response = new
            {
                statusCode,
                message
            };

            await context.Response.WriteAsJsonAsync(response);
        }
    }
}
