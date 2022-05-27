using System.Threading.Channels;

namespace WebApplication1;

public class TaskQueue : ITaskQueue
{
    private readonly Channel<Action<CancellationToken>> _queue;

    public TaskQueue()
    {
        var options = new BoundedChannelOptions(10)
        {
            FullMode = BoundedChannelFullMode.Wait,
        };
        
        _queue = Channel.CreateBounded<Action<CancellationToken>>(options);
        
    }
    public ValueTask Queue(Action<CancellationToken> workItem)
    {
        if(workItem is null)
        {
            throw new ArgumentNullException(nameof(workItem));
        }
        
        return _queue.Writer.WriteAsync(workItem);
    }

    public ValueTask<Action<CancellationToken>> Dequeue(CancellationToken cancellationToken)
    {
        if(cancellationToken.IsCancellationRequested)
        {
            return new ValueTask<Action<CancellationToken>>(Task.FromCanceled<Action<CancellationToken>>(cancellationToken));
        }
        
        return _queue.Reader.ReadAsync(cancellationToken);
    }
}