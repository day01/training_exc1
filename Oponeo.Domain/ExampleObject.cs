namespace Oponeo.Domain;

public class ExampleObject : Entity
{
    public string StringValue { get; set; }

    public int IntValue { get; set; }

    public decimal DecimalValue { get; set; }

    public ExampleStatus ExampleStatus { get; set; }

    public List<SubExampleObject> SubExampleObjects { get; set; }
}