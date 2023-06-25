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

        builder.RegisterTypes(Assembly.GetAssembly(typeof(RoomFactory))
                .GetTypes()
                .Where(x => x.Name.EndsWith("Factory"))
                .ToArray())
            .AsSelf();

        builder.RegisterTypes(Assembly.GetAssembly(typeof(AddRoomCommandHandler))
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