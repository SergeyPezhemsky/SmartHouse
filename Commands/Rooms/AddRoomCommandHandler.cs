using Domain.Rooms;
using Persistance.Models.Rooms.Write;

namespace Commands.Rooms;

public class AddRoomCommandHandler : ICommandHandler<AddRoomCommand>
{
    private readonly RoomFactory _roomFactory;
    private readonly IRoomRepository _roomRepository;

    public AddRoomCommandHandler(RoomFactory roomFactory, IRoomRepository roomRepository)
    {
        _roomFactory = roomFactory;
        _roomRepository = roomRepository;
    }
    
    public void Handle(AddRoomCommand command)
    {
        var room = _roomFactory.Create(command.Name);
        _roomRepository.Add(room);
    }
}