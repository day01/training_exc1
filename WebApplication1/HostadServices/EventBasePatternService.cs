namespace WebApplication1.HostadServices;

public class EventBasePatternService : BackgroundService
{
    private readonly ITaskQueue _taskQueue;
    private readonly ILogger<EventBasePatternService> _logger;

    public EventBasePatternService(
        ITaskQueue taskQueue,
        ILogger<EventBasePatternService> logger)
    {
        _taskQueue = taskQueue;
        _logger = logger;
    }


    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("{HostedServiceName}, is starting.", nameof(EventBasePatternService));

        return MainLoop(stoppingToken);
    }
    
    

    public override Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("{HostedServiceName} is stopping.", nameof(EventBasePatternService));
        
        return base.StopAsync(cancellationToken);
    }

    private async Task MainLoop(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            try
            {
                var eventBaseProcess = await _taskQueue.Dequeue(cancellationToken);

                eventBaseProcess(cancellationToken);

            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error in {HostedServiceName}.", nameof(EventBasePatternService));
            }
        }
    }
}