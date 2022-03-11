namespace Oponeo.Domain;

public abstract class Parameter : Entity
{
    public string Name { get; set; }

    public abstract string Type { get; set; }
}