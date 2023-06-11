namespace Domain.Devices;

class Device : IDevice
{
    public Guid Id { get; set; }
    public Guid? RoomId { get; set; }
    public string Name { get; set; }

    public Device(Guid id, string name, Guid? roomId = null)
    {
        Id = id;
        Name = name;
        RoomId = roomId;
    }

    public Device(string name, Guid? roomId = null)
    {
        Name = name;
        RoomId = roomId;
    }

    public void SetName(string name)
    {
        Name = name;
    }
}