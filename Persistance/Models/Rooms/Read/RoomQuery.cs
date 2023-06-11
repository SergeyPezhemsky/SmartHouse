using Queries.Room;
using Queries.Room.Models;

namespace Persistance.Models.Rooms.Read;

public class RoomQuery : IRoomQuery
{
    public IEnumerable<Room> Execute()
    {
        var db = new SmartHouseContext();

        return db.RoomDto.ToList().Select(x => new Room
        {
            Name = x.Name,
            Id = x.Id
        });
    }
}