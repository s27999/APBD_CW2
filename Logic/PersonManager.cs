using APBD_CW2.Database;

namespace APBD_CW2.Logic;

public class PersonManager
{
    private AppDatabase _appDatabase;
    
    public PersonManager(AppDatabase database)
    {
        this._appDatabase = database;
    }
    
    
}