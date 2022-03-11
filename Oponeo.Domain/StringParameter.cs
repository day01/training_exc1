namespace Oponeo.Domain;

public class StringParameter: Parameter
{
    public string StringValue { get; set; }

    // discriminator
    public override string Type { get; set; } = "String";

}