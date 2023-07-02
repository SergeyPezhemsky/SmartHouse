using AutoMapper;
using Domain.Devices;

namespace Persistance.Models.Devices.Write;

public class DeviceWriteMappingProfile : Profile
{
    public DeviceWriteMappingProfile()
    {
        CreateMap<IDevice, DeviceDto>();
    }
}