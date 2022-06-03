using System.Collections.Concurrent;
using System.Collections.Immutable;

namespace ConcurrentAndImmutableCollectionsVerificationConsoleApp;

public class PerfTestImmutableVsConcurrent
{
    private ImmutableDictionary<string, int> _immutableDictionary = ImmutableDictionary<string, int>.Empty;

    private readonly ConcurrentDictionary<string, int> _concurrentDictionary = new();

    public PerfTestImmutableVsConcurrent(int sizeOfDicts)
    {
        for (var i = 0; i < sizeOfDicts; i++)
        {
            _concurrentDictionary[$"OponeoKeyNo{i}"] = i;
            _immutableDictionary = _immutableDictionary.Add($"OponeoKeyNo{i}", i);
        }
    }

    public Task<long> ImmutableTest(int threads)
    {
        return SumTest(_immutableDictionary, threads);
    }

    public Task<long> Concurrent(int threads)
    {
        return SumTest(_concurrentDictionary, threads);
    }

    private async Task<long> SumTest(IReadOnlyDictionary<string, int> collection, int threads)
    {
        var tasks = new List<Task<long>>();
        for (var i = 0; i < threads; i++)
        {
            var task = Task.Run(() =>
            {
                long s = 0;
                foreach (var key in collection.Keys)
                {
                    s += collection[key];
                }

                return s;
            });
            tasks.Add(task);
        }

        var result = await Task.WhenAll(tasks);

        return result.Sum();
    }
}