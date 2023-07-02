using Domain.Rooms;

namespace Queries.Room.Models;

public class Room
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public RoomKind RoomKind { get; set; }
}