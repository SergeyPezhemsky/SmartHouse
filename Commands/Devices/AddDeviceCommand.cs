namespace Commands.Devices;

public class AddDeviceCommand
{
    public string Name { get; }
    public Guid? RoomId { get; }

    public AddDeviceCommand(string name, Guid? roomId = null)
    {
        Name = name;
        RoomId = roomId;
    }
}