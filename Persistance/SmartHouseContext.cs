using Microsoft.EntityFrameworkCore;
using Persistance.Models.Devices;
using Persistance.Models.Rooms;

namespace Persistance;

public class SmartHouseContext : DbContext
{
    public SmartHouseContext(DbContextOptions<SmartHouseContext> options) : base(options)
    {

    }

    public DbSet<RoomDto> RoomDto { get; set; }
    public DbSet<DeviceDto> DeviceDto { get; set; }
}