using Domain.Devices;

namespace Persistance.Models.Devices.Write;

public class DeviceRepository : Repository, IDeviceRepository
{
    public DeviceRepository(SmartHouseContext smartHouseContext) : base(smartHouseContext)
    {

    }

    public void Add(IDevice device)
    {
        var deviceDto = new DeviceDto()
        {
            Id = device.Id,
            Name = device.Name,
            RoomId = device.RoomId
        };

        _smartHouseContext.DeviceDto.Add(deviceDto);
        _smartHouseContext.SaveChanges();
    }
}