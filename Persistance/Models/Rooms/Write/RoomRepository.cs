using Domain.Rooms;

namespace Persistance.Models.Rooms.Write;

public class RoomRepository : IRoomRepository
{
    public void Add(IRoom room)
    {
        var roomDto = new RoomDto
        {
            Id = room.Id,
            Name = room.Name
        };

        var db = new SmartHouseContext();

        db.RoomDto.Add(roomDto);
        db.SaveChanges();
    }
}