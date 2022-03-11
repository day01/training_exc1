namespace Oponeo.Domain;

public class IntParameter : Parameter
{
    public override string Type { get; set; } = "Int";

    public int? IntValue { get; set; }
}