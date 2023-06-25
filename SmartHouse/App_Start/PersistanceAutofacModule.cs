using System;
using System.Linq;
using System.Reflection;
using Autofac;
using Persistance;
using Module = Autofac.Module;

namespace SmartHouse;

public class PersistanceAutofacModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<SmartHouseContext>()
            .InstancePerLifetimeScope();

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

        builder.RegisterTypes(assembly
                .GetTypes()
                .Where(x => x.IsSubclassOf(typeof(Query)))
                .ToArray())
            .AsImplementedInterfaces();
    }
}