using Domain.Rooms;

namespace Persistance.Models.Rooms.Write;

public class RoomRepository : Repository, IRoomRepository
{
    public RoomRepository(SmartHouseContext smartHouseContext) : base(smartHouseContext)
    {
        
    }
    public void Add(IRoom room)
    {
        var roomDto = new RoomDto
        {
            Id = room.Id,
            Name = room.Name
        };
        
        _smartHouseContext.RoomDto.Add(roomDto);
        _smartHouseContext.SaveChanges();
    }
}