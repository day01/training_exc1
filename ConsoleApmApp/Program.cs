// See https://aka.ms/new-console-template for more information

using System.Net;
using ConsoleApmApp;

public class Program
{
    public static event EventHandler<IPHostEntry> HostEntryDownloaded;
    
    public static void Main()
    {
        HostEntryDownloaded += LogDnsInformation;
        HostEntryDownloaded += LogDnsInformation2;
        var srv = new ExampleService();
        var importantLogResultAboutSecuritySoWeHaveToSeeItBeforeExitFromProgram = srv.LogMeAsync();
        // Pobranie informacji na temat IP ktore chcemy przeanalizować
        while (true)
        {
            Console.WriteLine("Podaj prosze adresy IP ktore chcesz przeanalizowac rozdzielajac je spacja");
            var hosts = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(hosts))
            {
                Console.WriteLine("Podana nazwa hosta jest nullem, wylaczam program");
                
                break;
            }

            var callback = new AsyncCallback(AsyncDnsInformation);

            var hostnames = hosts.Split(" ");

            foreach (var hostname in hostnames)
            {
                var result = Dns.BeginGetHostEntry(hostname, callback, hostname);
            }
        }

        importantLogResultAboutSecuritySoWeHaveToSeeItBeforeExitFromProgram.AsyncWaitHandle.WaitOne();
        // save_file()
    }

    public static void AsyncDnsInformation(IAsyncResult asyncResult)
    {
        var hostname = (string)asyncResult.AsyncState;
        Thread.Sleep(TimeSpan.FromSeconds(5));

        var loggingPrefix = $"Task: '{Thread.CurrentThread.ManagedThreadId}', looking for hostname '{hostname}' | ";
        Console.WriteLine(loggingPrefix + "Begin");
        
        try
        {
            var host = Dns.EndGetHostEntry(asyncResult);
            HostEntryDownloaded.Invoke(host.HostName, host);
        }
        catch (Exception e)
        {
            Console.WriteLine(loggingPrefix + e);
        }
    }

    public static void LogDnsInformation(object? sender, IPHostEntry hostEntry)
    {
        var loggingPrefix = $"Task: '{Thread.CurrentThread.ManagedThreadId}', looking for hostname '{sender}' | ";

        Console.WriteLine($"{loggingPrefix}Verify information about: {sender}");
        foreach (var alias in hostEntry.Aliases)
        {
            Console.WriteLine(loggingPrefix + alias);
        }
    }
    
    public static void LogDnsInformation2(object? sender, IPHostEntry hostEntry)
    {
        var loggingPrefix = $"Task: '{Thread.CurrentThread.ManagedThreadId}', looking for hostname '{sender}' | ";

        Console.WriteLine($"{loggingPrefix}Verify information about: {sender}");

        foreach (var ipAddress in hostEntry.AddressList)
        {
            Console.WriteLine(loggingPrefix + ipAddress);
        }
    }
}