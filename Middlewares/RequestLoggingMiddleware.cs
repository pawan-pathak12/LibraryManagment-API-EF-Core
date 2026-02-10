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

            // 1️⃣ Log request
            _logger.LogInformation(
                "Request started: {Method} {Path}",
                context.Request.Method,
                context.Request.Path
            );

            await _next(context); // controller runs here

            // 2️⃣ Log response
            var duration = DateTime.UtcNow - startTime;

            _logger.LogInformation(
                "Request finished: {Method} {Path} | Status: {StatusCode} | Time: {Duration}ms",
                context.Request.Method,
                context.Request.Path,
                context.Response.StatusCode,
                duration.TotalMilliseconds
            );
        }

    }
}
