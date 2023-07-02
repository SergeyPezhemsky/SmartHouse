using AutoMapper;

namespace SmartHouse.Controllers.Room.Models;

public class RoomMappingProfile : Profile
{
    public RoomMappingProfile()
    {
        CreateMap<RoomDto, Queries.Room.Models.Room>().ReverseMap();
    }
}