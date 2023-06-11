namespace Domain.Devices;

public interface IDevice
{
    Guid Id { get; }
    Guid? RoomId { get; }
    string Name { get; }
}