using Domain.Rooms;
using Persistance.Models.Write;

namespace Commands.Rooms;

public class AddRoomCommandHandler : ICommandHandler<AddRoomCommand>
{
    public void Handle(AddRoomCommand command)
    {
        var repository = new RoomRepository();
        var room = new Room(Guid.NewGuid(), "Спальня");

        repository.Add(room);
    }
}