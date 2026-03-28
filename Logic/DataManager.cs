using APBD_CW2.Database;
using APBD_CW2.Models;

namespace APBD_CW2.Logic;


public class DataManager
{
    private AppDatabase _appDatabase;
    
    public DataManager(AppDatabase database)
    {
        this._appDatabase = database;
    }

    public List<Equipment> getAllEquipment()
    {
        return _appDatabase.Equipment;
    }

    public List<Person> getAllPersons()
    {
        return this._appDatabase.Persons;
    }

    public List<RentEquipment> getAllRentEquipment()
    {
        return this._appDatabase.RentEquipment;
    }
    
    public List<Equipment> getAvailableEquipment()
    {
        List<Equipment> availableEquipment = new List<Equipment>();
        foreach (Equipment e in _appDatabase.Equipment)
        {
            if (e.Availability == EquipmentStatus.Dostepny)
            {
                availableEquipment.Add(e);   
            }
        }
        return availableEquipment;
    }

    public List<RentEquipment> getPersonRent(Person person)
    {
        List<RentEquipment> personRent = new List<RentEquipment>();
        foreach (RentEquipment rentEquipment in _appDatabase.RentEquipment)
        {
            if (rentEquipment.PersonId == person.Id)
            {
                personRent.Add(rentEquipment);
            }
        }
        return personRent;
    }

    public List<RentEquipment> getOverdueRent()
    {
        List<RentEquipment> overdueRent = new List<RentEquipment>();
        foreach (RentEquipment rentEquipment in _appDatabase.RentEquipment)
        {
            if (rentEquipment.PlannedReturnDate < DateOnly.FromDateTime(DateTime.Now))
            {
                overdueRent.Add(rentEquipment);
            }
        }
        return overdueRent;
    }
}