using APBD3.Exeptions;

namespace APBD3.Models;

public abstract class Container
{
    public double CargoWeight { get; protected set; } = 0;
    public double Height { get; private set; }
    public double ContainerWeight { get; private set; }
    public double Depth { get; private set; }
    public SerialNumber SerialNumber { get; private set; }
    public double MaxCargoWeight { get; private set; }

    public double Volume => Depth * Height;

    public Container(double height, double containerWeight, double depth, SerialNumber serialNumber, double maxCargoWeight)
    {
        Height = height;
        ContainerWeight = containerWeight;
        Depth = depth;
        SerialNumber = serialNumber;
        MaxCargoWeight = maxCargoWeight;
    }

    public virtual void LoadCargo(double cargoToAdd)
    {
        CargoWeight += cargoToAdd;
        if (CargoWeight > MaxCargoWeight)
        {
            throw new OverfillException();
        }
    }

    public virtual void UnloadCargo()
    {
        CargoWeight = 0;
    }

    public override string ToString()
    {
        return $"Container Details:\n" +
               $"Serial Number: {SerialNumber}\n" +
               $"Height: {Height} meters\n" +
               $"Depth: {Depth} meters\n" +
               $"Container Weight: {ContainerWeight} kg\n" +
               $"Max Cargo Weight: {MaxCargoWeight} kg\n" +
               $"Current Cargo Weight: {CargoWeight} kg";
    }

}