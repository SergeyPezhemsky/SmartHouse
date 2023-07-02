using Microsoft.EntityFrameworkCore;
using Queries.Room;
using Queries.Room.Models;

namespace Persistance.Models.Rooms.Read;

public class RoomQuery : Query, IRoomQuery
{
    public RoomQuery(SmartHouseContext smartHouseContext) : base(smartHouseContext)
    {
    }

    public IEnumerable<Room> Execute()
    {
        return _smartHouseContext.RoomDto.AsNoTracking().ToList().Select(x => new Room
        {
            Name = x.Name,
            Id = x.Id,
            RoomKind = x.RoomKind
        });
    }
}