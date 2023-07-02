namespace Domain.Rooms;

public class RoomFactory
{
    public IRoom Restore(Guid id, string name, RoomKind roomKind)
    {
        return new Room(id, name, roomKind);
    }

    public IRoom Create(string name, RoomKind roomKind)
    {
        return new Room(Guid.NewGuid(), name, roomKind);
    }
}