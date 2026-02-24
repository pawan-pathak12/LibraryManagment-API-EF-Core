namespace Library_Management_API.API.Middlewares
{
    public class SimpleBlockMiddleware
    {
        private readonly RequestDelegate _next;

        public SimpleBlockMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.ContainsKey("X-Client-Key"))
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync("Missing client key");
                return; // stop pipeline
            }
            await _next(context);
        }
    }
}
