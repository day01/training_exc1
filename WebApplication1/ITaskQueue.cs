namespace WebApplication1;

public interface ITaskQueue
{
    ValueTask Queue(Action<CancellationToken> workItem);
    
    ValueTask<Action<CancellationToken>> Dequeue(CancellationToken cancellationToken);
}