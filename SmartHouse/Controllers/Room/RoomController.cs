using System.Collections.Generic;
using System.Linq;
using Commands;
using Commands.Rooms;
using Domain.Rooms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Queries.Room;
using SmartHouse.Controllers.Room.Models;

namespace SmartHouse.Controllers.Room;

[Route("[controller]")]
public class RoomController : Controller
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IRoomQuery _roomQuery;
    
    public RoomController(ILogger<ApiController> logger, ICommandDispatcher commandDispatcher, IRoomQuery roomQuery)
    {
        _commandDispatcher = commandDispatcher;
        _roomQuery = roomQuery;
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
        return _roomQuery.Execute().Select(x => new RoomDto
        {
            Name = x.Name
        });
    }
}