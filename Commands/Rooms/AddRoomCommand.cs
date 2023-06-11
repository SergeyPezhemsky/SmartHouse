namespace Commands.Rooms;

public class AddRoomCommand
{
    public string Name { get; }

    public AddRoomCommand(string name)
    {
        Name = name;
    }
}