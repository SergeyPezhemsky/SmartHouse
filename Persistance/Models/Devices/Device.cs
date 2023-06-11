using Persistance.Models.Rooms;

namespace Persistance.Models.Devices;

public class DeviceDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid? RoomId { get; set; }
    public RoomDto? Room { get; set; }
}