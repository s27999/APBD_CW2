using APBD_CW2.Database;

namespace APBD_CW2.Logic;


public class DataManager
{
    private AppDatabase _appDatabase;
    
    public DataManager(AppDatabase database)
    {
        this._appDatabase = database;
    }
}