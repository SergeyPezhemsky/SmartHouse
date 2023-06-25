using Microsoft.EntityFrameworkCore;
using Persistance.Models.Devices;
using Persistance.Models.Rooms;

namespace Persistance;

public class SmartHouseContext : DbContext
{
    public SmartHouseContext()
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(
            @"Host=localhost;Port=5432;Database=smarthouse;Username=smarthouseuser;Password=smarthouse");
    }
    
    public DbSet<RoomDto> RoomDto { get; set; }
    public DbSet<DeviceDto> DeviceDto { get; set; }
}