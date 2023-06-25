using Domain.Rooms;
using Persistance.Models.Rooms.Write;

namespace Commands.Rooms;

public class AddRoomCommandHandler : ICommandHandler<AddRoomCommand>
{
    private readonly RoomFactory _roomFactory;

    public AddRoomCommandHandler(RoomFactory roomFactory)
    {
        _roomFactory = roomFactory;
    }
    
    public void Handle(AddRoomCommand command)
    {
        var repository = new RoomRepository();
        var room = _roomFactory.Create(command.Name);

        repository.Add(room);
    }
}