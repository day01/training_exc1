using System.Diagnostics;
using System.Security.Cryptography;

namespace Apm.Exc1;

public class ApmAsync
{
    private readonly EventHandler _eventHandler;

    public ApmAsync()
    {
        _eventHandler += LogMsg;
        GenerateDummyFile("./dummy_file_key");
        _eventHandler("dummy file", new SourceFileIsGenerated());
    }

    private void LogMsg(object? sender, EventArgs args)
    {
        if (args is SourceFileIsGenerated)
        {
            Console.WriteLine("File is generated correctly");
        }

        if (args is TargetFileIsGenerated)
        {
            Console.WriteLine("Target file is generated correctly");
        }

        if (args is ShaCalculated)
        {
            Console.WriteLine("SHA calculated correctly");
        }
    }

    private void GenerateDummyFile(string filename)
    {
        const int blockSize = 1024 * 8;
        const int blocksPerMb = (1024 * 1024) / blockSize;
        var data = new byte[blockSize];
        using var crypto = RandomNumberGenerator.Create();
        using var stream = File.OpenWrite(filename);
        for (var i = 0; i < 1024 * blocksPerMb; i++)
        {
            crypto.GetBytes(data);
            stream.Write(data, 0, data.Length);
        }
    }

    private void GenAndReadFile()
    {
        var sw = new Stopwatch();
        sw.Start();
        var path = "./dummy_file_" + Random.Shared.NextInt64();
        GenerateDummyFile(path);
        _eventHandler("target file", new TargetFileIsGenerated());
        
        var bytes = File.ReadAllBytes(path);
        var keybytes = File.ReadAllBytes("./dummy_file_key");
        Thread.Sleep(TimeSpan.FromSeconds(10));
        HMACSHA512.HashData(keybytes, bytes);
        _eventHandler("SHA", new ShaCalculated());
        sw.Stop();
    }

    public IAsyncResult CalculateSha()
    {
        return Task.Run(GenAndReadFile);
    }

    private delegate void AsyncMethod();
}