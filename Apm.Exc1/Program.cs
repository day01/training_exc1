// See https://aka.ms/new-console-template for more information

using Apm.Exc1;

Console.WriteLine("Hello, World!");

var a = new ApmAsync();
var count = int.Parse(args[0]);
var list = new List<Task>();
var cancellationToken = new CancellationToken();

Console.WriteLine("start");
for (var i = 0; i < count; i++)
{
    list.Add(a.CalculateSha(cancellationToken));
}

Task.WhenAll(list);

Console.WriteLine("end");
