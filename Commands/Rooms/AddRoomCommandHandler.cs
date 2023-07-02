using Domain.Rooms;

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
        if (command.Name == null)
        {
            throw new ArgumentNullException("Name cannot be null");
        }
        
        var room = _roomFactory.Create(command.Name, command.RoomKind);
        _roomRepository.Add(room);
    }
}