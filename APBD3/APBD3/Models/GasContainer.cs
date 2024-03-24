using APBD3.Exeptions;

namespace APBD3.Models;

public class GasContainer : Container, IHazardNotifier
{
    public double Pressure => CargoWeight / Volume;
    
    public GasContainer(double height,
        double containerWeight,
        double depth,
        SerialNumber serialNumber,
        double maxCargoWeight) : base(height,
        containerWeight,
        depth,
        serialNumber,
        maxCargoWeight)
    {
    }

    public override void LoadCargo(double cargoToAdd)
    {
        try
        {
            base.LoadCargo(cargoToAdd);
        }
        catch (OverfillException)
        {
            SendNotification(new HazardNotification("Gas overfilled", SerialNumber));
            throw;
        }
    }

    public override void UnloadCargo()
    {
        CargoWeight *= 0.05;
    }
    
    private void SendNotification(HazardNotification notification)
    {
        foreach (var listener in _listeners)
            listener.Invoke(notification);
    }

    private readonly List<Action<HazardNotification>> _listeners = new();

    public void Subscribe(Action<HazardNotification> listener) => 
        _listeners.Add(listener);

    public void Unsubscribe(Action<HazardNotification> listener) => 
        _listeners.Remove(listener);
}