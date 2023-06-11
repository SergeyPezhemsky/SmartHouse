using System;

namespace SmartHouse.Controllers.Device.Models;

public class DeviceDto
{
    public string Name { get; set; }
    public Guid? RoomId { get; set; }
}