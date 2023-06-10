using System.Reflection;

namespace Domain.Rooms;

public class Room
{
    public string Name { get; set; }

    public Room(string name)
    {
        Name = name;
    }

    public void SetName(string name)
    {
        Name = name;
    }
}