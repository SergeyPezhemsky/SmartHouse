using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Commands;
using Commands.Rooms;
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
    private readonly IMapper _mapper;

    public RoomController(ILogger<ApiController> logger,
        ICommandDispatcher commandDispatcher,
        IRoomQuery roomQuery,
        IMapper mapper)
    {
        _commandDispatcher = commandDispatcher;
        _roomQuery = roomQuery;
        _mapper = mapper;
    }

    [HttpPost]
    public void Room([FromBody] RoomDto roomDto)
    {
        var command = new AddRoomCommand(roomDto.Name, roomDto.RoomKind);
        _commandDispatcher.Dispatch(command);
    }

    [HttpGet]
    public IEnumerable<RoomDto> Rooms()
    {
        var rooms = _roomQuery.Execute();

        return _mapper.Map<IEnumerable<Queries.Room.Models.Room>, IEnumerable<RoomDto>>(rooms);
    }
}