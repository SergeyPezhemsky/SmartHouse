
namespace Queries.Room;

public interface IRoomQuery
{
    IEnumerable<Models.Room> Execute();
}