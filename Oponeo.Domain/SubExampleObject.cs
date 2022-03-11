namespace Oponeo.Domain;

public class SubExampleObject
{
    public long Id { get; set; }

    public string Name { get; set; }

    public ExampleObject ExampleObject { get; set; }
}