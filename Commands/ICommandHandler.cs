namespace Commands;

public interface ICommandHandler<in TInput, out TOutput>
{
    TOutput Handle(TInput command);
}

public interface ICommandHandler<in TInput>
{
    void Handle(TInput command);
}