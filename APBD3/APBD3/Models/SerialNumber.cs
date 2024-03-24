namespace APBD3.Models;

public class SerialNumber : IEquatable<SerialNumber>
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

    public bool Equals(SerialNumber? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return _id == other._id && Type == other.Type;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((SerialNumber)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_id, (int)Type);
    }

    public static bool operator ==(SerialNumber? left, SerialNumber? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(SerialNumber? left, SerialNumber? right)
    {
        return !Equals(left, right);
    }
}

public enum ContainerType
{
    Liquid,
    Gas,
    Cooling
}