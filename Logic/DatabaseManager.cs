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
    
    public Person getRenterToCheck(string Id)
    {
        foreach (Person p in _appDatabase.Persons)
        {
            if (p.Id == Id)
            {
                return p;

            }
        }

        return null;
    }
    public Equipment getEquipmentToCheck(String Id)
    {
        foreach (Equipment e in _appDatabase.Equipment)
        {
            if (e.Id == Id)
            {
                return e;

            }
        }

        return null;
    }
    
    public RentEquipment getRentEquipmentToCheck(String equipmentId, String EquipmentId)
    {
        foreach (RentEquipment e in _appDatabase.RentEquipment)
        {
            if (e.PersonId == equipmentId && e.EquipmentId == EquipmentId)
            {
                return e;

            }
        }

        return null;
    }
    
    public Service getServiceToCheck(String Id)
    {
        foreach (Service s in _appDatabase.Services)
        {
            if (s.Id == Id)
            {
                return s;

            }
        }

        return null;
    }
}