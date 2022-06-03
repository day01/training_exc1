// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");
var exampleBoolean = false;
var yieldNo = 0;

var taskSpinWait = Task.Factory.StartNew(() =>
{
   var spinWait = new SpinWait();
   while (!exampleBoolean)
   {
      if (spinWait.NextSpinWillYield) yieldNo++;
      
      spinWait.SpinOnce();
   }
   
   Console.WriteLine($"Called {spinWait.Count} yield {yieldNo}");
});

var waiter = Task.Factory.StartNew(() =>
{
   Thread.Sleep(TimeSpan.FromSeconds(1));
   exampleBoolean = true;
});

Task.WaitAll(taskSpinWait, waiter);