using APBD_CW2.Logic;
using APBD_CW2.Models;

namespace APBD_CW2.UI;

public class ConsoleUI
{
    private EquipmentManager _equipmentManager;
    private DataManager _dataManager;
    private DatabaseManager _databaseManager;
    private EquipmentUI _equipmentUI;

    public ConsoleUI(EquipmentManager equipmentManager, DataManager dataManager, DatabaseManager databaseManager)
    {
        _equipmentManager = equipmentManager;
        _dataManager = dataManager;
        _databaseManager = databaseManager;
        _equipmentUI = new EquipmentUI(_equipmentManager, _dataManager, _databaseManager);
    }

    public void Start()
    {
        bool isWorking = true;
        
        
        while (isWorking)
        {
                
        }
    }

    private void DisplayMainMenu()
    {
        Console.WriteLine("     WYPOZYCZALNIA SPRZETU ELEKTRONICZNEGO       ");
        Console.WriteLine("1. Zarzadzaj Sprzetem");
        Console.WriteLine("2. Zarzadzaj Uzytkownikami");
        Console.WriteLine("3. Wyswietl Raporty");
    }

    private void AddPerson()
    {
        Console.WriteLine("Wybierz rodzaj uzytkownika");
        Console.WriteLine("1. Employee");
        Console.WriteLine("2. Student");

        string choice = Console.ReadLine();
        
        Console.WriteLine("Podaj Imie Uzytkownika");
        string name = Console.ReadLine();
        
        Console.WriteLine("Podaj Nazwisko");
        string lastName = Console.ReadLine();
        
        switch (choice)
        {
            case "1":
                Employee employee = new Employee(name, lastName);
                _databaseManager.addNewPerson(employee);
                break;
            case "2":
                Student student =  new Student(name, lastName);
                _databaseManager.addNewPerson(student);
                break;
        }
    }

    
}