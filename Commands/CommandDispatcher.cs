using System.Reflection;

namespace Commands;

public class CommandDispatcher : ICommandDispatcher
{
    public void Dispatch<TCommand>(TCommand command) where TCommand : class
    {
        Type handler = typeof(ICommandHandler<>);
        Type handlerType = handler.MakeGenericType(command.GetType());

        Type[] concreteTypes = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t.IsClass && t.GetInterfaces().Contains(handlerType))
            .ToArray();
        
        if (!concreteTypes.Any()) return;

        foreach (Type type in concreteTypes)
        {
            var concreteHandler = Activator.CreateInstance(type)
                as ICommandHandler<TCommand>;
            
            concreteHandler?.Handle(command);
        }
    }
}