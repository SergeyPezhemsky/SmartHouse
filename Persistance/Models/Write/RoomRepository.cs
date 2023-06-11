using Domain.Rooms;
using Persistance.Models.Rooms;

namespace Persistance.Models.Write;

public class RoomRepository
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