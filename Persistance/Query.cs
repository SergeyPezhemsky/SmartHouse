namespace Persistance;

public class Query
{
    protected readonly SmartHouseContext _smartHouseContext;

    protected Query(SmartHouseContext smartHouseContext)
    {
        _smartHouseContext = smartHouseContext;
    }
}