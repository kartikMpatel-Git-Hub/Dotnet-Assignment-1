namespace product_store.Middleware
{
    public static class LoggerMiddlewareExtention
    {
        public static IApplicationBuilder UseLogger(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggerMiddleware>();
        }
    }
}
