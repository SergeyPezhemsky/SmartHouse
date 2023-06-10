using Microsoft.EntityFrameworkCore;
using Persistance.Models.Rooms;

namespace Persistance;

public class SmartHouseContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(
            @"Host=localhost;Port=5432;Database=smarthouse;Username=smarthouseuser;Password=smarthouse");
    }
    
    public DbSet<RoomDto> RoomDto { get; set; }
}