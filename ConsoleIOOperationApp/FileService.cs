using System.Text;

namespace ConsoleIOOperationApp;

public class FileService
{
    private object _lock = new();
    private ReaderWriterLockSlim _rwl = new();
    public async Task Test1()
    {
        var file = File.Open("incredible.file", FileMode.OpenOrCreate, FileAccess.Write);
        await TestCases(() => WriteMultipleTimes(file));
        file.Close();
    }
    
    private void Write(string content, FileStream file)
    {
        var bytes = Encoding.UTF8.GetBytes(content);
        file.Write(bytes, 0, bytes.Length);
    }

    private void WriteMultipleTimes(FileStream fileStream)
    {
        for (var i = 0; i < 100_000; i++)
        {
            lock (_lock)
            {
                Write(i.ToString(), fileStream);
            }
        }
    }
    
    private void WriteMultipleTimes2(FileStream fileStream)
    {
        for (var i = 0; i < 100_000; i++)
        {
            _rwl.EnterWriteLock();
            {
                Write(i.ToString(), fileStream);
            }
            _rwl.ExitWriteLock();
        }
    }

    private Task TestCases(Action action)
    {
        var t1 = Task.Run(action);
        var t2 = Task.Run(action);
        var t3 = Task.Run(action);
        var t4 = Task.Run(action);
        var t5 = Task.Run(action);
        
        return Task.WhenAll(t1, t2, t3, t4, t5);
    }

    public async Task Test2()
    {
        
        if(File.Exists("incredible.file"))
        {
            File.Delete("incredible.file");
        }
        var file = File.Open("incredible.file", FileMode.OpenOrCreate, FileAccess.Write);
        await TestCases(() => WriteMultipleTimes2(file));
        file.Close();
    }
}