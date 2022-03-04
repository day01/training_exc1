namespace Oponeo.Domain;

public class OponeoAddingService : IOponeoAddingService, IIocScoped
{
    private readonly IRepository _repository;

    public OponeoAddingService(IRepository repository)
    {
        _repository = repository;
    }
}