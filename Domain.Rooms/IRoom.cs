namespace Domain.Rooms;

public interface IRoom
{
    Guid Id { get; }
    string Name { get; }
}