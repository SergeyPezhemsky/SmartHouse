using Domain.Rooms;

namespace Commands.Rooms;

public class AddRoomCommand
{
    public string? Name { get; }
    public RoomKind RoomKind { get; }

    public AddRoomCommand(string? name, RoomKind roomKind)
    {
        Name = name;
        RoomKind = roomKind;
    }
}