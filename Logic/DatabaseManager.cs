using APBD_CW2.Database;
using APBD_CW2.Models;

namespace APBD_CW2.Logic;

public class DatabaseManager
{
    private AppDatabase _appDatabase;
    
    public DatabaseManager(AppDatabase database)
    {
        this._appDatabase = database;
    }

    public void addNewPerson(Person person)
    {
        _appDatabase.AddToPersonsList(person);
    }

    public void addNewEquipment(Equipment equipment)
    {
        _appDatabase.AddToEquipmentList(equipment);
    }
    
    
}