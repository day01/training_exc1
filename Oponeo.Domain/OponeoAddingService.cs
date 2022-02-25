namespace Oponeo.Domain;

public class OponeoAddingService : IOponeoAddingService
{
    private readonly IRepository _repository;

    public OponeoAddingService(IRepository repository)
    {
        _repository = repository;
    }
}