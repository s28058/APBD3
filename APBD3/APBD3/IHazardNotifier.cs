using APBD3.Models;

namespace APBD3;

public interface IHazardNotifier
{
    public void Subscribe(Action<HazardNotification> listener);

    public void Unsubscribe(Action<HazardNotification> listener);
}