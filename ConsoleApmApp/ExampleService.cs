using System.Reflection;

namespace ConsoleApmApp;

public class ExampleService
{
    public delegate void LongLoggingFunction();

    public void LogMeWithLongTimeDelay()
    {
        Console.WriteLine(Environment.CurrentManagedThreadId + " - " + DateTime.Now);
        Thread.Sleep(TimeSpan.FromSeconds(5));
        Console.WriteLine(Environment.CurrentManagedThreadId + " - " + DateTime.Now);
    }

    public IAsyncResult LogMeAsync()
    {
        // var caller = new LongLoggingFunction(this.LogMeWithLongTimeDelay);
        // caller.BeginInvoke(null, null);

        return Task.Run(LogMeWithLongTimeDelay);
    }
}