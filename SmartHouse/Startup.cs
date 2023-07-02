using System;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Persistance;
using Persistance.Models.Devices.Write;
using Persistance.Models.Rooms.Write;
using SmartHouse.Controllers.Device.Models;
using SmartHouse.Controllers.Room.Models;

namespace SmartHouse;

public class Startup
{
    public IConfiguration Configuration { get; }
    
    public Startup(IWebHostEnvironment env, IConfiguration configuration)
    {
        if (env is null)
            throw new ArgumentNullException("env is null");

        Configuration = configuration ?? throw new ArgumentNullException("configuration is null");
    }
    
    public void ConfigureServices(IServiceCollection services)
    {
        if (services is null)
            throw new Exception("services is null");

        services.AddDbContext<SmartHouseContext>(options =>
        {
            options.UseNpgsql(Configuration.GetConnectionString("SmartHouseContext"));
        });
        
        services.AddMvc()
            .AddXmlSerializerFormatters();
        
        services.AddMvcCore()
            .AddApiExplorer();
        services.AddSwaggerGen();

        services.AddAutoMapper(typeof(RoomMappingProfile));
        services.AddAutoMapper(typeof(DeviceMappingProfile));
        services.AddAutoMapper(typeof(RoomWriteMappingProfile));
        services.AddAutoMapper(typeof(DeviceWriteMappingProfile));
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IConfiguration configuration,
        ILoggerFactory loggerFactory)
    {
        if (app is null)
            throw new ArgumentNullException("app is null");

        if (env is null)
            throw new ArgumentNullException("env is null");

        if (configuration is null)
            throw new ArgumentNullException("configuration is null");

        if (loggerFactory is null)
            throw new ArgumentNullException("loggerFactory is null");
        
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseRouting();

        app.UseEndpoints(e =>
        {
            e.MapControllers();
        });
    }

    public void ConfigureContainer(ContainerBuilder builder)
    {
        builder.RegisterModule(new CommandsAutofacModule());
        builder.RegisterModule(new PersistanceAutofacModule());
    }
}