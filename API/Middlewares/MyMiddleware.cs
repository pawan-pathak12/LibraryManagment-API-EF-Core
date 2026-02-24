namespace Library_Management_API.API.Middlewares
{
    public class MyMiddleware
    {
        private readonly RequestDelegate _next;

        public MyMiddleware(RequestDelegate next)
        {
            this._next = next;
        }
        public async Task InvokeAsync(HttpContext content)
        {
            // before controller 

            await _next(content);  // pass to next middleware

            //after controller
        }
    }
}
