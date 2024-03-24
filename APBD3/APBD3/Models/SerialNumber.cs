namespace APBD3.Models;

public class SerialNumber
{
    private const string Prefix = "KON";
    public ContainerType Type { get; }
    private readonly int _id;

    public SerialNumber(ContainerType type, int id)
    {
        Type = type;
        _id = id;
    }

    private string TypeLabel => 
        Type switch
        {
            ContainerType.Cooling => "C",
            ContainerType.Gas => "G",
            ContainerType.Liquid => "L",
            _ => throw new ArgumentOutOfRangeException()
        };

    public override string ToString()
    {
        return $"{Prefix}-{TypeLabel}-{_id}";
    }
}

public enum ContainerType
{
    Liquid,
    Gas,
    Cooling
}