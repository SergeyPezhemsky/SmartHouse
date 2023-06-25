using System;
using System.Linq;
using System.Reflection;
using Autofac;
using Commands;
using Commands.Rooms;
using Domain.Rooms;
using Module = Autofac.Module;

namespace SmartHouse;

public class CommandsAutofacModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<CommandDispatcher>().As<ICommandDispatcher>().AsSelf();

        var roomFactoryAssembly = Assembly.GetAssembly(typeof(RoomFactory));
        if (roomFactoryAssembly == null)
        {
            throw new ArgumentNullException("RoomFactory assembly is null");
        }
        
        builder.RegisterTypes(roomFactoryAssembly
                .GetTypes()
                .Where(x => x.Name.EndsWith("Factory"))
                .ToArray())
            .AsSelf();
        
        var commandHandlerAssembly = Assembly.GetAssembly(typeof(AddRoomCommandHandler));
        if (commandHandlerAssembly == null)
        {
            throw new ArgumentNullException("CommandHandler assembly is null");
        }

        builder.RegisterTypes(commandHandlerAssembly
                .GetTypes()
                .Where(x => x.GetInterfaces().Any(i =>
                    i.IsGenericType &&
                    new[] { typeof(ICommandHandler<,>), typeof(ICommandHandler<>) }.Contains(
                        i.GetGenericTypeDefinition())))
                .ToArray())
            .AsImplementedInterfaces()
            .AsSelf();
    }
}