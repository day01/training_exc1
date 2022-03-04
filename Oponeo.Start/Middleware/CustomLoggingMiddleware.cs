using System.Diagnostics;

namespace Oponeo.Start.Middleware;

public class CustomLoggingMiddleware
{
    public static Func<HttpContext, Func<Task>, Task> Handle()
    {
        return async (context, next) =>
        {
            var sw = new Stopwatch();
            var logger = context.RequestServices.GetService(typeof(ILogger<CustomLoggingMiddleware>)) as ILogger;
            logger.LogInformation("Logging remote {Ip}", context.Connection.RemoteIpAddress);
            sw.Start();
            await next();
            sw.Stop();
            
            logger.LogInformation("Execution time: {ExecutionTime}", sw.Elapsed);
        };
    }
}