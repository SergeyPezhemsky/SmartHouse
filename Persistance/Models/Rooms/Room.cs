using System;
using Domain.Rooms;

namespace Persistance.Models.Rooms;

public class RoomDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public RoomKind RoomKind { get; set; }
}