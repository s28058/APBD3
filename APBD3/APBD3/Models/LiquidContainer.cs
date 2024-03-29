using System.Diagnostics.CodeAnalysis;

namespace APBD3.Models;

public class LiquidContainer : Container, IHazardNotifier
{
    public CargoDanger CargoDanger { get; }
    
    public LiquidContainer(
        double height,
        double containerWeight,
        double depth,
        SerialNumber serialNumber,
        double maxCargoWeight,
        CargoDanger cargoDanger) : 
        base(
        height,
        containerWeight,
        depth,
        serialNumber,
        maxCargoWeight)
    {
        if (serialNumber.Type != ContainerType.Liquid)
            throw new InvalidOperationException("Wrong type");
        
        CargoDanger = cargoDanger;
    }

    private double CargoLimit => CargoDanger switch
    {
        CargoDanger.Hazardous => 0.5 * MaxCargoWeight,
        CargoDanger.Safe => 0.9 * MaxCargoWeight,
        _ => throw new ArgumentOutOfRangeException()
    };

    public override void LoadCargo(double cargoToAdd)
    {
        base.LoadCargo(cargoToAdd);
        if (CargoWeight > CargoLimit)
        {
            SendNotification(new HazardNotification("Liquid threshold exciting", SerialNumber));
        }
    }
    
    public override string ToString()
    {
        return $"Liquid Container Details:\n" +
               $"Serial Number: {SerialNumber}\n" +
               $"Height: {Height} meters\n" +
               $"Depth: {Depth} meters\n" +
               $"Container Weight: {ContainerWeight} kg\n" +
               $"Max Cargo Weight: {MaxCargoWeight} kg\n" +
               $"Current Cargo Weight: {CargoWeight} kg\n" +
               $"Cargo Danger: {CargoDanger}\n" +
               $"Cargo Limit: {CargoLimit} kg\n";
    }

    private void SendNotification(HazardNotification notification)
    {
        foreach (var listener in _listeners)
            listener.Invoke(notification);
    }

    private readonly List<Action<HazardNotification>> _listeners = new();

    public void Subscribe(Action<HazardNotification> listener)
    {
        _listeners.Add(listener);
    }

    public void Unsubscribe(Action<HazardNotification> listener)
    {
        _listeners.Remove(listener);
    }
}