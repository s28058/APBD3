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