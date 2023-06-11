using Domain.Devices;
using Persistance.Models.Devices.Write;

namespace Commands.Devices;

public class AddDeviceCommandHandler: ICommandHandler<AddDeviceCommand>
{
    public void Handle(AddDeviceCommand command)
    {
        var repository = new DeviceRepository();
        var device = new DeviceFactory().Create(command.Name, command.RoomId);

        repository.Add(device);
    }
}