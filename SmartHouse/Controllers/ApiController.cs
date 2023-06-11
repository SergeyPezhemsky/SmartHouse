using System;
using Domain.Rooms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Persistance.Models.Write;

namespace SmartHouse.Controllers;

[Route("[controller]/[action]")]
public class ApiController : Controller
{
    public ApiController(ILogger<ApiController> logger)
    {
    }
    
    [HttpPost]
    public void Add()
    {
        var repository = new RoomRepository();
        var room = new Room(Guid.NewGuid(), "Спальня");

        repository.Add(room);
        
    }
}