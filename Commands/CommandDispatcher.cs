using System.Reflection;
using Autofac;

namespace Commands;

public class CommandDispatcher : ICommandDispatcher
{
    private readonly ILifetimeScope _scope;
    
    public CommandDispatcher(ILifetimeScope scope)
    {
        _scope = scope;
    }
    public void Dispatch<TCommand>(TCommand command) where TCommand : class
    {
        _scope.Resolve<ICommandHandler<TCommand>>().Handle(command);
    }
}