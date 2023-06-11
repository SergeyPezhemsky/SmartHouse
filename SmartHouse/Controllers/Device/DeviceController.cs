using Commands;
using Commands.Devices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartHouse.Controllers.Device.Models;

namespace SmartHouse.Controllers.Device;

[Route("[controller]")]
public class DeviceController
{
    private readonly ICommandDispatcher _commandDispatcher;
    
    public DeviceController(ILogger<ApiController> logger, ICommandDispatcher commandDispatcher)
    {
        _commandDispatcher = commandDispatcher;
    }
    
    [HttpPost]
    public void Device([FromBody] DeviceDto deviceDto)
    {
        var command = new AddDeviceCommand(deviceDto.Name, deviceDto.RoomId);
        _commandDispatcher.Dispatch(command);
    }
}