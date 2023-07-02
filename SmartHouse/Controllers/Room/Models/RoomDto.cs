using System;
using Domain.Rooms;

namespace SmartHouse.Controllers.Room.Models;

public class RoomDto
{
    public string? Name { get; set; }
    public Guid? Id { get; set; }
    public RoomKind RoomKind { get; set; }
}