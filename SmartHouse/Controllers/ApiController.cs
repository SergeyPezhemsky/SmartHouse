using System;
using Commands;
using Commands.Rooms;
using Domain.Rooms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Persistance.Models.Write;

namespace SmartHouse.Controllers;

[Route("[controller]/[action]")]
public class ApiController : Controller
{
    private readonly ICommandDispatcher _commandDispatcher;
    
    public ApiController(ILogger<ApiController> logger, ICommandDispatcher commandDispatcher)
    {
        _commandDispatcher = commandDispatcher;
    }
    
    [HttpPost]
    public void Add()
    {
        var command = new AddRoomCommand("Спальня");
        _commandDispatcher.Dispatch(command);
    }
}