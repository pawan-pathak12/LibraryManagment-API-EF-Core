namespace Library_Management_API.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next,
            ILogger<RequestLoggingMiddleware> logger)
        {
            this._next = next;
            this._logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var startTime = DateTime.UtcNow;

            _logger.LogInformation(
               "Request started: {Method} {Path}",
               context.Request.Method,
               context.Request.Path
           );

            await _next(context);   // controller execute here


            var duration = DateTime.UtcNow - startTime;


            _logger.LogInformation(
                "Request finished in {Duration} ms",
                duration.TotalMilliseconds
            );

        }

    }
}
