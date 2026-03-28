using APBD_CW2.Logic;
using APBD_CW2.Models;

namespace APBD_CW2.UI;

public class EquipmentUI
{
    private EquipmentManager _equipmentManager;
    private DataManager _dataManager;
    private DatabaseManager _databaseManager;

    public EquipmentUI(EquipmentManager equipmentManager, DataManager dataManager, DatabaseManager databaseManager)
    {
        _equipmentManager = equipmentManager;
        _dataManager = dataManager;
        _databaseManager = databaseManager;
    }
    
    private void AddEquipment()
    {
        Console.WriteLine("Wybierz rodzaj equipment");
        Console.WriteLine("1. Laptop");
        Console.WriteLine("2. Camera");
        Console.WriteLine("3. Projector");
        string choice = Console.ReadLine();
    }
    
    private Laptop AddLaptop()
    {
        Console.WriteLine("Nazwa Laptopa:");
        string name = Console.ReadLine();
        
        Console.WriteLine("Informacje o Laptopie:");
        string data = Console.ReadLine();
        
        Console.WriteLine("Procesor Laptopa:");
        string procesor = Console.ReadLine();
        
        Console.WriteLine("Karta Graficzna laptopa:");
        string gpu = Console.ReadLine();
        
        return new Laptop(name, data, procesor, gpu);
    }
    
    private Camera AddCamera()
    {
        Console.WriteLine("Nazwa Kamery:");
        string name = Console.ReadLine();
        
        Console.WriteLine("Informacje o Kamerze:");
        string data = Console.ReadLine();
        
        Console.WriteLine("Rozdzielczosc:");
        string resolution = Console.ReadLine();
        
        Console.WriteLine("Iso:");
        string iso = Console.ReadLine();
        
        return new Camera(name, data, resolution, iso);
    }
    
    private Projector AddProjector()
    {
        Console.WriteLine("Nazwa Projektora:");
        string name = Console.ReadLine();
        
        Console.WriteLine("Informacje o Projektorze:");
        string data = Console.ReadLine();
        
        Console.WriteLine("Rozdzielczosc:");
        string resolution = Console.ReadLine();
        
        Console.WriteLine("Jasnosc:");
        string iso = Console.ReadLine();
        
        return new Projector(name, data, resolution, iso);
    }
}