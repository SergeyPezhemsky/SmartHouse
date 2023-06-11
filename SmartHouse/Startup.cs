﻿using Microsoft.AspNetCore.Mvc;

namespace SmartHouse;

public class Startup
{
    public Startup(IWebHostEnvironment env, IConfiguration configuration)
    {
        if (env is null)
            throw new ArgumentNullException("env is null");

        if (configuration is null)
            throw new ArgumentNullException("configuration is null");
    }
    
    public void ConfigureServices(IServiceCollection services)
    {
        if (services is null)
            throw new Exception("services is null");
        
        services.AddMvc()
            .AddXmlSerializerFormatters();
        
        services.AddMvcCore()
            .AddApiExplorer();
        services.AddSwaggerGen();

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
}