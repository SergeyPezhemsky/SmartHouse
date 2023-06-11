namespace Domain.Devices;

public class DeviceFactory
{
    public IDevice Restore(Guid id, string name, Guid? roomId = null)
    {
        return new Device(id, name, roomId);
    }

    public IDevice Create(string name, Guid? roomId = null)
    {
        return new Device(Guid.NewGuid(), name, roomId);
    }
}