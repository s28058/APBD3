namespace APBD3.Models.Base;

public abstract class Container
{
    public int CargoWeight { get; private set; }
    public int Height { get; private set; }
    public int ContainerWeight { get; private set; }
    public int Depth { get; private set; }
    public string SerialNumber { get; private set; }
    public int MaxWeight { get; private set; }

    public Container(int cargoWeight, int height, int containerWeight, int depth, string serialNumber, int maxWeight)
    {
        CargoWeight = cargoWeight;
        Height = height;
        ContainerWeight = containerWeight;
        Depth = depth;
        SerialNumber = serialNumber;
        MaxWeight = maxWeight;
    }

    public void LoadCargo()
    {
        
    }

    public void UnloadCargo()
    {
        
    }
    
    
}