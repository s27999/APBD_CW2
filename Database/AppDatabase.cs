using APBD_CW2.Models;

namespace APBD_CW2.Database;

public class AppDatabase
{
    private List<Person> _persons = new List<Person>();
    private List<Equipment> _equipment = new List<Equipment>();
    private List<RentEquipment> _rentEquipment = new List<RentEquipment>();
    
    
    public AppDatabase()
    {}
    
    public void AddToPersonsList(Person person)
    {
        this._persons.Add(person);
    }

    public void AddToEquipmentList(Equipment equipment)
    {
        this._equipment.Add(equipment);
    }

    public void AddToRentEquipmentList(RentEquipment rentEquipment)
    {
        this._rentEquipment.Add(rentEquipment);
    }
    
    public List<Person> Persons => this._persons;
    public List<Equipment> Equipment => this._equipment;
    public List<RentEquipment> RentEquipment => this._rentEquipment;
}