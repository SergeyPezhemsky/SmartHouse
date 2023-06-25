using Domain.Devices;

namespace Commands.Devices;

public class AddDeviceCommandHandler: ICommandHandler<AddDeviceCommand>
{
    private readonly IDeviceRepository _deviceRepository;
    private readonly DeviceFactory _deviceFactory;

    public AddDeviceCommandHandler(IDeviceRepository deviceRepository, DeviceFactory deviceFactory)
    {
        _deviceRepository = deviceRepository;
        _deviceFactory = deviceFactory;
    } 
    
    public void Handle(AddDeviceCommand command)
    {
        if (command.Name == null)
        {
            throw new ArgumentNullException("Name cannot be null");
        }
        
        var device = _deviceFactory.Create(command.Name, command.RoomId);

        _deviceRepository.Add(device);
    }
}