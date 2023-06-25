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
        
        builder.RegisterTypes(Assembly.GetAssembly(typeof(SmartHouseContext))
                .GetTypes()
                .Where(x => x.IsSubclassOf(typeof(Repository)))
                .ToArray())
            .AsImplementedInterfaces();
    }
}