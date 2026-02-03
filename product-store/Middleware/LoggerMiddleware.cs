using System.Diagnostics;

namespace product_store.Middleware
{
    public class LoggerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggerMiddleware> _logger;

        public LoggerMiddleware(RequestDelegate next, ILogger<LoggerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {

            _logger.LogInformation("Request of {Method} on {Path} at {Time}",
                context.Request.Method,
                context.Request.Path,
                DateTime.Now);
            await _next(context);

        }
    }
}