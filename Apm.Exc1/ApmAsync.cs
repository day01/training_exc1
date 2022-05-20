using System.Diagnostics;
using System.Security.Cryptography;

namespace Apm.Exc1;

public class ApmAsync
{
    public ApmAsync()
    {
        const int blockSize = 1024 * 8;
        const int blocksPerMb = (1024 * 1024) / blockSize;

        var data = new byte[blockSize];

        using var crypto = RandomNumberGenerator.Create();
        using var stream = File.OpenWrite("./dummy_file");
        for (var i = 0; i < 1024 * blocksPerMb; i++)
        {
            crypto.GetBytes(data);
            stream.Write(data, 0, data.Length);
        }
    }

    private void ReadFile()
    {
        var sw = new Stopwatch();
        sw.Start();
        var bytes = File.ReadAllBytes("./dummy_file");
        var keybytes = File.ReadAllBytes("./dummy_file");
        Thread.Sleep(TimeSpan.FromSeconds(1));
        HMACSHA512.HashData(keybytes, bytes);
        sw.Stop();
    }

    public IAsyncResult CalculateSha()
    {
        return Task.Run(ReadFile);
    }
    
    private delegate void AsyncMethod();
}