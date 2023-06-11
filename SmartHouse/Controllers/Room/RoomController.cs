using System.Collections.Generic;
using System.Linq;
using Commands;
using Commands.Rooms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Persistance.Models.Rooms.Read;
using SmartHouse.Controllers.Room.Models;

namespace SmartHouse.Controllers.Room;

[Route("[controller]")]
public class RoomController : Controller
{
    private readonly ICommandDispatcher _commandDispatcher;
    
    public RoomController(ILogger<ApiController> logger, ICommandDispatcher commandDispatcher)
    {
        _commandDispatcher = commandDispatcher;
    }
    
    [HttpPost]
    public void Room([FromBody] RoomDto roomDto)
    {
        var command = new AddRoomCommand(roomDto.Name);
        _commandDispatcher.Dispatch(command);
    }

    [HttpGet]
    public IEnumerable<RoomDto> Rooms()
    {
        var query = new RoomQuery();
        return query.Execute().Select(x => new RoomDto
        {
            Name = x.Name
        });
    }
}