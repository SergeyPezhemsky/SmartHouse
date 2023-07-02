namespace Domain.Rooms;

class Room : IRoom
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public RoomKind RoomKind { get; set; }

    public Room(Guid id, string name, RoomKind roomKind)
    {
        Id = id;
        Name = name;
        RoomKind = roomKind;
    }

    public Room(string name)
    {
        Name = name;
    }

    public void SetName(string name)
    {
        Name = name;
    }
}