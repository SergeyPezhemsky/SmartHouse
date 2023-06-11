namespace Domain.Rooms;

public class RoomFactory
{
    public IRoom Restore(Guid id, string name)
    {
        return new Room(id, name);
    }

    public IRoom Create(string name)
    {
        return new Room(Guid.NewGuid(), name);
    }
}