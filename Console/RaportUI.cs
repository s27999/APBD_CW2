using APBD_CW2.Logic;
using APBD_CW2.Models;

namespace APBD_CW2.UI;

public class RaportUI
{
    private EquipmentManager _equipmentManager;
    private DataManager _dataManager;
    private DatabaseManager _databaseManager;
    
    public RaportUI(EquipmentManager equipmentManager, DataManager dataManager, DatabaseManager databaseManager)
    {
        _equipmentManager = equipmentManager;
        _dataManager = dataManager;
        _databaseManager = databaseManager;
    }

    public void StartRaportUI()
    {
        bool inMenu = true;

        while (inMenu)
        {
            Console.WriteLine("Wybierz Akcje:");
            Console.WriteLine("1. Wyswietl caly sprzet ze statusem");
            Console.WriteLine("2. Wyswietl sprzet do wypozyczenia");
            Console.WriteLine("3. Wyswietl wypozyczenia uzytkownika");
            Console.WriteLine("4. Wyswietl przeterminowane wypozyczenia");
            Console.WriteLine("5. Raport stanu wypozyczalni");
            Console.WriteLine("6. Powrot");

            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    WygenerujListeSprzetu();
                    break;
                case "2":
                    WygenerujListeDoWypozyczenia();
                    break;
                case "3":
                    WygenerujWypozyczeniaUzytkownika();
                    break;
                case "4":
                    WygenerujPrzeterminowaneWypozyczenia();
                    break;
                case "5":
                    WygenerujRaport();
                    break;
                case "6":
                    inMenu = false;
                    break;
            }
        }
    }

    public void WygenerujListeSprzetu()
    {
        foreach (Equipment e in _dataManager.getAllEquipment())
        {
            Console.WriteLine($"ID: {e.Id}  Nazwa: {e.Name}  Status: {e.Availability}  Informacje: {e.Data}");
        }
    }

    public void WygenerujListeDoWypozyczenia()
    {
        foreach (Equipment e in _dataManager.getAvailableEquipment())
        {
            Console.WriteLine($"ID: {e.Id}  Nazwa: {e.Name}  Status: {e.Availability}  Informacje: {e.Data}");
        }
    }

    public void WygenerujWypozyczeniaUzytkownika()
    {
        Console.WriteLine("ID Uzytkownika:");
        string Id = Console.ReadLine();
        Person person = _databaseManager.getRenterToCheck(Id);
        
        Console.WriteLine($"Wypozyczenia uzytkownika {Id}:");
        foreach (RentEquipment e in _dataManager.getPersonRent(person))
        {
            Console.WriteLine($"ID Przedmiotu: {e.EquipmentId}  Data Wypozyczenia: {e.RentDate}  Planowana data zwrotu: {e.PlannedReturnDate}");
        }
    }

    public void WygenerujPrzeterminowaneWypozyczenia()
    {
        foreach (RentEquipment e in _dataManager.getOverdueRent())
        {
            int overdueDays = DateOnly.FromDateTime(DateTime.Today).DayNumber - e.PlannedReturnDate.DayNumber;
            Console.WriteLine($"ID Przedmiotu: {e.EquipmentId}  Data Wypozyczenia: {e.RentDate}  Planowana data zwrotu: {e.PlannedReturnDate}  Zaległe dni: {overdueDays}");
        }
    }

    public void WygenerujRaport()
    {
        Console.WriteLine("Osoby Zarejestrowane w systemie:");
        foreach (Person p in _dataManager.getAllPersons())
        {
            Console.WriteLine($"ID: {p.Id}   Imie: {p.Name}  Nazwisko: {p.LastName}");
        }
        Console.WriteLine();
        Console.WriteLine("Lista przedmiotów:");
        WygenerujListeSprzetu();
        
        Console.WriteLine();
        Console.WriteLine();
    }
}