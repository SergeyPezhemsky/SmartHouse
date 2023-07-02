using AutoMapper;
using Domain.Devices;

namespace Persistance.Models.Devices.Write;

public class DeviceRepository : Repository, IDeviceRepository
{
    private readonly IMapper _mapper;

    public DeviceRepository(SmartHouseContext smartHouseContext, IMapper mapper) : base(smartHouseContext)
    {
        _mapper = mapper;
    }

    public void Add(IDevice device)
    {
        var deviceDto = _mapper.Map<IDevice, DeviceDto>(device);

        _smartHouseContext.DeviceDto.Add(deviceDto);
        _smartHouseContext.SaveChanges();
    }
}