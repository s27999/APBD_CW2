using APBD_CW2.Database;
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

    public void StartEquipmentUI()
    {
        bool inMenu = true;

        while (inMenu)
        {
            Console.WriteLine("Wybierz akcje");
                    Console.WriteLine("1. Dodaj sprzęt");
                    Console.WriteLine("2. Wypożycz sprzęt");
                    Console.WriteLine("3. Zwróć sprzęt");
                    Console.WriteLine("4. Oddaj sprzęt do serwisu");
                    Console.WriteLine("5. Powrót");
                    string choice = Console.ReadLine();
            
                    switch (choice)
                    {
                        case "1":
                            AddEquipment();
                            break;
                        case  "2":
                            RentEquipment();
                            break;
                        case "3":
                            ReturnEquipment();
                            break;
                        case "4":
                            ServiceEquipment();
                            break;
                        case "5":
                            inMenu = false;
                            Console.Clear();
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("nieznana Opcja");
                            break;
                    }
        }
        
    }
    
    private void AddEquipment()
    {
        bool inMenu = true;

        while (inMenu)
        {
            Console.WriteLine("Wybierz rodzaj equipment");
            Console.WriteLine("1. Laptop"); 
            Console.WriteLine("2. Camera"); 
            Console.WriteLine("3. Projector"); 
            string choice = Console.ReadLine();
            
            switch  (choice) 
            { 
                case "1": 
                    _databaseManager.addNewEquipment(AddLaptop()); 
                    break;
                
                case "2": 
                    _databaseManager.addNewEquipment(AddCamera()); 
                    break;
                
                case "3": 
                    _databaseManager.addNewEquipment(AddProjector()); 
                    break;
            }
        }
        
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


    private void RentEquipment()
    {
        Person person = null;
        Equipment equipment = null;
        DateOnly plannedReturnDate;
        
        while (true)
        {
            Console.WriteLine("Podaj Id Uzytkownika:");
            person = _databaseManager.getRenterToCheck(Console.ReadLine());

            if (person != null)
            {
                break;
            }
        }
        
        while (true)
        {
            Console.WriteLine("Podaj Id Przedmiotu:");
            equipment = _databaseManager.getEquipmentToCheck(Console.ReadLine());

            if (equipment != null)
            {
                break;
            }
        }
        
        Console.WriteLine("Wpisz poprawną datę (RRRR-MM-DD): ");
        while (!DateOnly.TryParse(Console.ReadLine(), out plannedReturnDate))
        {
            Console.WriteLine("Nieprawidłowy format daty");
            Console.Write("Wpisz poprawną datę (RRRR-MM-DD): ");
        }
        
        _equipmentManager.rentEquipment(new RentEquipment(person, equipment, DateOnly.FromDateTime(DateTime.Today), plannedReturnDate));
    }
    
    private void ReturnEquipment()
    {
        Person person = null;
        Equipment equipment = null;
        RentEquipment rentEquipment = null;
        
        while (true)
        {
            Console.WriteLine("Podaj Id Uzytkownika:");
            person = _databaseManager.getRenterToCheck(Console.ReadLine());

            if (person != null)
            {
                break;
            }
        }
        
        while (true)
        {
            Console.WriteLine("Podaj Id Przedmiotu:");
            equipment = _databaseManager.getEquipmentToCheck(Console.ReadLine());

            if (equipment != null)
            {
                break;
            }
        }
        
        /*foreach (RentEquipment r in _appDatabase.RentEquipment)
        {
            if (r.PersonId == person.Id &&  r.EquipmentId == equipment.Id)
            {
                rentEquipment = r;
            }
        }*/
        
        
        _equipmentManager.returnEquipment(_databaseManager.getRentEquipmentToCheck(equipment.Id, person.Id));
    }

    private void ServiceEquipment()
    {
        Equipment equipment;
        string sercviceDescription;

        while (true)
        {
            Console.WriteLine("Podaj Id Przedmiotu:");
            equipment = _databaseManager.getEquipmentToCheck(Console.ReadLine());

            if (equipment != null)
            {
                break;
            }
        }
        Console.WriteLine("Opis usterki:");
        sercviceDescription = Console.ReadLine();
        
        Service service = new Service(equipment, sercviceDescription);
        
        _equipmentManager.addService(service);
    }
    
    //Dodac kod na odznaczenie serwisu
}