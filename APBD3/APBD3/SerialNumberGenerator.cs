using APBD3.Models;

namespace APBD3;

public class SerialNumberGenerator
{
    private int _nextFreeId = 0;

    public SerialNumber Get(ContainerType type) => new SerialNumber(type, _nextFreeId++);
}