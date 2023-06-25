using System;
using System.Linq;
using System.Reflection;
using Autofac;
using Domain.Rooms;
using Persistance;
using Persistance.Models.Rooms.Write;
using Module = Autofac.Module;

namespace SmartHouse;

public class PersistanceAutofacModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<SmartHouseContext>()
            .InstancePerLifetimeScope();
        //.WithParameters(new NamedParameter("connectionString"))

        var assembly = Assembly.GetAssembly(typeof(SmartHouseContext));
        if (assembly == null)
        {
            throw new ArgumentNullException("SmartHouseContext assembly is null");
        }
        
        builder.RegisterTypes(assembly
                    .GetTypes()
                    .Where(x => x.IsSubclassOf(typeof(Repository)))
                    .ToArray())
                .AsImplementedInterfaces();
    }
}