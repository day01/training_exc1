namespace OponeoBehavior.Specs.Drivers;

public class Calculator
{
    public int? FirstNumber { get; set; }

    public int? SecondNum { get; set; }

    public int? Result { get; set; }
    
    public void AddTwoNumbers()
    {
        Result = FirstNumber + SecondNum;
    }
    
    public void SubtractTwoNumbers()
    {
        Result = FirstNumber - SecondNum;
    }
    
    public void Reset()
    {
        FirstNumber = null;
        SecondNum = null;
        Result = null;
    }
}