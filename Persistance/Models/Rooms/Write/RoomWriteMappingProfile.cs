using AutoMapper;
using Domain.Rooms;

namespace Persistance.Models.Rooms.Write;

public class RoomWriteMappingProfile : Profile
{
    public RoomWriteMappingProfile()
    {
        CreateMap<IRoom, RoomDto>();
    }
}