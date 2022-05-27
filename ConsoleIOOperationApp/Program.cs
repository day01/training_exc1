// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using ConsoleIOOperationApp;
using Medallion.Threading.Redis;
using StackExchange.Redis;

Console.WriteLine("Great Oponeo App!");

ThreadPool.GetMaxThreads(out var workerThreads, out var completionPortThreads);
Console.WriteLine("Worker Threads: {0}", workerThreads);
Console.WriteLine("CompletionPort Threads: {0}", completionPortThreads);

var resource = 0;
var resource1 = 0;
var resource2 = 0;
var resource3 = 0;
var resource4 = 0;
var resource5 = 0;
var fileService = new FileService();
var sw = new Stopwatch();
var obj = new Object();
var rwl = new ReaderWriterLockSlim();
var mut = new Mutex();
var semaphore = new Semaphore(1, 1);
var connectionString =
    "test-purpose-olszewski.redis.cache.windows.net:6380,password=RJSnIMsloZC6cfh40CgMGFGw7PYRa42E1AzCaJPQawA=,ssl=True,abortConnect=False";
var connection = await ConnectionMultiplexer.ConnectAsync(connectionString);

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
Console.WriteLine("Time elapsed for Test2: {0}", sw.Elapsed);

sw.Start();
fileService.Test1().Wait();
sw.Stop();
Console.WriteLine("Value of resource: " + resource);
Console.WriteLine("Time elapsed for Test1 file: {0}", sw.Elapsed);

sw.Reset();
sw.Start();
fileService.Test2().Wait();
sw.Stop();
Console.WriteLine("Value of resource: " + resource);
Console.WriteLine("Time elapsed for Test2 file: {0}", sw.Elapsed);

sw.Reset();
sw.Start();
Test3().Wait();
sw.Stop();
Console.WriteLine("Value of resource: " + resource3);
Console.WriteLine("Time elapsed for TestMutex: {0}", sw.Elapsed);

sw.Reset();
sw.Start();
Test4().Wait();
sw.Stop();
Console.WriteLine("Value of resource: " + resource4);
Console.WriteLine("Time elapsed for TestSemaphore: {0}", sw.Elapsed);

sw.Reset();
sw.Start();
Test5().Wait();
sw.Stop();
Console.WriteLine("Value of resource: " + resource5);
Console.WriteLine("Time elapsed for TestSemaphore: {0}", sw.Elapsed);

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

Task Test3()
{
    var t1 = Task.Run(IncrementMutex);
    var t2 = Task.Run(IncrementMutex);
    var t3 = Task.Run(IncrementMutex);
    var t4 = Task.Run(IncrementMutex);
    var t5 = Task.Run(IncrementMutex);
    return Task.WhenAll(t1, t2, t3, t4, t5);
}

Task Test4()
{
    var t1 = Task.Run(IncrementSemaphore);
    var t2 = Task.Run(IncrementSemaphore);
    var t3 = Task.Run(IncrementSemaphore);
    var t4 = Task.Run(IncrementSemaphore);
    var t5 = Task.Run(IncrementSemaphore);
    return Task.WhenAll(t1, t2, t3, t4, t5);
}

Task Test5()
{
    var t1 = IncrementDistributedLock();
    var t2 = IncrementDistributedLock();
    var t3 = IncrementDistributedLock();
    var t4 = IncrementDistributedLock();
    var t5 = IncrementDistributedLock();
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

void IncrementMutex()
{
    for (int i = 0; i < 100_000; i++)
    {
        mut.WaitOne();
        resource3++;
        mut.ReleaseMutex();
    }
}

void IncrementSemaphore()
{
    for (int i = 0; i < 100_000; i++)
    {   
        semaphore.WaitOne(TimeSpan.FromSeconds(1));
        resource4++;
        semaphore.Release();
    }
}

async Task IncrementDistributedLock()
{
    for (int i = 0; i < 100_000; i++)
    {
        var @lock = new RedisDistributedLock("OponeoKey", connection.GetDatabase());
        await using var handle = await @lock.TryAcquireAsync();
        if (handle != null)
        {
            resource5++;
        }
    }
}