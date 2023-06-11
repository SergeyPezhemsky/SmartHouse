using Domain.Devices;

namespace Persistance.Models.Devices.Write;

public class DeviceRepository : IDeviceRepository
{
    public void Add(IDevice device)
    {
        var deviceDto = new DeviceDto()
        {
            Id = device.Id,
            Name = device.Name,
            RoomId = device.RoomId
        };

        var db = new SmartHouseContext();

        db.DeviceDto.Add(deviceDto);
        db.SaveChanges();
    }
}