namespace Oponeo.Domain;

public abstract class Parameter
{
    public long Id { get; set; }
    
    public string Name { get; set; }

    public abstract string Type { get; set; }
}