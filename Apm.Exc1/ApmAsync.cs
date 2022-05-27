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

    private async Task GenAndReadFile(CancellationToken cancellationToken)
    {
        var sw = new Stopwatch();
        sw.Start();
        var path = "./dummy_file_" + Random.Shared.NextInt64();
        GenerateDummyFile(path);
        _eventHandler("target file", new TargetFileIsGenerated());

        cancellationToken.ThrowIfCancellationRequested();
        var delay = Task.Delay(TimeSpan.FromSeconds(10));
        var bytes = await Task.WhenAll(
            File.ReadAllBytesAsync(path, cancellationToken),
            File.ReadAllBytesAsync("./dummy_file_key", cancellationToken)
            );

        await delay;

        HMACSHA512.HashData(bytes[1], bytes[0]);
        _eventHandler("SHA", new ShaCalculated());
        sw.Stop();
    }

    public Task CalculateSha(CancellationToken cancellationToken)
    {
        return GenAndReadFile(cancellationToken);
    }
}