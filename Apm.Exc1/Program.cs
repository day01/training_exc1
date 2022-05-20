// See https://aka.ms/new-console-template for more information

using Apm.Exc1;

Console.WriteLine("Hello, World!");

var a = new ApmAsync();
var count = int.Parse(args[0]);
var list = new List<IAsyncResult>();

Console.WriteLine("start");
for (var i = 0; i < count; i++)
{
    list.Add(a.CalculateSha());
}

foreach (var asyncResult in list)
{
    if (asyncResult.IsCompleted)
    {
        if (list.Any(x => !x.IsCompleted))
        {
            continue;
        }

        break;
    }
    asyncResult.AsyncWaitHandle.WaitOne(10);
}
Thread.Sleep(TimeSpan.FromSeconds(10));

Console.WriteLine("end");
