using System.Net;

namespace Oponeo.Start.Middleware;

public class CustomLoggingMiddleware
{
    public static Func<HttpContext, Func<Task>, Task> Handle()
    {
        return async (context, next) =>
        {
            var logger = context.RequestServices.GetService(typeof(ILogger<CustomLoggingMiddleware>)) as ILogger ??
                         throw new NullReferenceException("logger error");
            logger.LogInformation("Logging remote {ip}", context.Connection.RemoteIpAddress);
            await next();
        };
    }
}