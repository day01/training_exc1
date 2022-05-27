// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using System.Runtime.CompilerServices;

Console.WriteLine("Great Oponeo App!");

var resource = 0;

var sw = new Stopwatch();

sw.Start();
Test1().Wait();

sw.Stop();
Console.WriteLine("Value of resource: " + resource);
Console.WriteLine("Time elapsed for Test1: {0}", sw.Elapsed);

Task Test1()
{
    var t1 = Task.Run(Increment);
    var t2 = Task.Run(Increment);
    var t3 = Task.Run(Increment);
    var t4 = Task.Run(Increment);
    var t5 = Task.Run(Increment);
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