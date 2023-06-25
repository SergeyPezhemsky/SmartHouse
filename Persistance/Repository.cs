namespace Persistance;

public class Repository
{
    protected readonly SmartHouseContext _smartHouseContext;

    protected Repository(SmartHouseContext smartHouseContext)
    {
        _smartHouseContext = smartHouseContext;
    }
}