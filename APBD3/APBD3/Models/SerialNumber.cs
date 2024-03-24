namespace APBD3.Models;

public class SerialNumber
{
    private const string Prefix = "KON";
    private readonly ContainerType _type;
    private readonly int _id;

    public SerialNumber(ContainerType type, int id)
    {
        _type = type;
        _id = id;
    }

    private string TypeLabel => 
        _type switch
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