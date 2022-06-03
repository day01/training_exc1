// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using System.Net.Http.Headers;
using SpinLockExampleConsoleApp;

public class Program
{
    private static Queue<DataExample> _queue = new();

    private static SpinLock _spinLock = new();

    public static void Main(string[] args)
    {
        SpinLockVerification();
    }


    public static void SpinLockVerification()
    {
        var sw = new Stopwatch();
        sw.Start();

        Parallel.Invoke(
            () =>
            {
                for (int i = 0; i < 100_000; i++)
                {
                    UpdateData(new DataExample {Name = $"Oponeo with key {i}", Value = i});
                }
            },
            () =>
            {
                for (int i = 0; i < 100_000; i++)
                {
                    UpdateData(new DataExample {Name = $"Oponeo second with key {i}", Value = i});
                }
            });

        sw.Stop();
        Console.WriteLine($"Information about the time {sw.ElapsedMilliseconds}");
    }

    private static void UpdateData(DataExample data)
    {
        var token = false;
        try
        {
            _spinLock.Enter(ref token);
            _queue.Enqueue(data);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        finally
        {
            if (token) _spinLock.Exit();
        }
    }
}