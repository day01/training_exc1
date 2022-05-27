// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using System.Runtime.CompilerServices;

Console.WriteLine("Great Oponeo App!");

ThreadPool.GetMaxThreads(out var workerThreads, out var completionPortThreads);
Console.WriteLine("Worker Threads: {0}", workerThreads);
Console.WriteLine("CompletionPort Threads: {0}", completionPortThreads);

var resource = 0;
var resource1 = 0;
var resource2 = 0;
var fileService = new FileService();
var sw = new Stopwatch();
var obj = new Object();
var rwl = new ReaderWriterLockSlim();

sw.Start();
Test0().Wait();
sw.Stop();
Console.WriteLine("Value of resource: " + resource);
Console.WriteLine("Time elapsed for Test0: {0}", sw.Elapsed);

sw.Reset();
sw.Start();
Test1().Wait();
sw.Stop();
Console.WriteLine("Value of resource: " + resource1);
Console.WriteLine("Time elapsed for Test1: {0}", sw.Elapsed);

sw.Reset();
sw.Start();
Test2().Wait();
sw.Stop();
Console.WriteLine("Value of resource: " + resource2);
Console.WriteLine("Time elapsed for Test1: {0}", sw.Elapsed);

//
// sw.Start();
// fileService.Test1().Wait();
// sw.Stop();
// Console.WriteLine("Value of resource: " + resource);
// Console.WriteLine("Time elapsed for Test1: {0}", sw.Elapsed);

Task Test0()
{
    var t1 = Task.Run(Increment);
    var t2 = Task.Run(Increment);
    var t3 = Task.Run(Increment);
    var t4 = Task.Run(Increment);
    var t5 = Task.Run(Increment);
    return Task.WhenAll(t1, t2, t3, t4, t5);
}

Task Test1()
{
    var t1 = Task.Run(Increment1);
    var t2 = Task.Run(Increment1);
    var t3 = Task.Run(Increment1);
    var t4 = Task.Run(Increment1);
    var t5 = Task.Run(Increment1);
    return Task.WhenAll(t1, t2, t3, t4, t5);
}

Task Test2()
{
    var t1 = Task.Run(Increment2);
    var t2 = Task.Run(Increment2);
    var t3 = Task.Run(Increment2);
    var t4 = Task.Run(Increment2);
    var t5 = Task.Run(Increment2);
    return Task.WhenAll(t1, t2, t3, t4, t5);
}

void Increment()
{
    for (var i = 0; i < 100_000; i++)
    {
        // nasza apka bierze wartosc resource z pamieci i dodaje 1
        // wiec wartosc resource w pamieci bedzie wieksza o 1
        // zapis laduje w tym samym miejscu czyli resource
        resource++;
    }
}

void Increment1()
{
    for (var i = 0; i < 100_000; i++)
    {
        lock (obj)
        {
            resource1++;
        }
    }
}

void Increment2()
{
    for (var i = 0; i < 100_000; i++)
    {
        rwl.EnterWriteLock();
        resource2++;
        rwl.ExitWriteLock();
    }
}