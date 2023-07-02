using AutoMapper;
using Domain.Rooms;

namespace Persistance.Models.Rooms.Write;

public class RoomRepository : Repository, IRoomRepository
{
    private readonly IMapper _mapper;

    public RoomRepository(SmartHouseContext smartHouseContext, IMapper mapper) : base(smartHouseContext)
    {
        _mapper = mapper;
    }

    public void Add(IRoom room)
    {
        var roomDto = _mapper.Map<IRoom, RoomDto>(room);
        
        _smartHouseContext.RoomDto.Add(roomDto);
        _smartHouseContext.SaveChanges();
    }
}