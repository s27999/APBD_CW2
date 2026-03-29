using APBD_CW2.Database;
using APBD_CW2.Models;

namespace APBD_CW2.Logic;

public class EquipmentManager
{
    private AppDatabase _appDatabase;

    public EquipmentManager(AppDatabase database)
    {
        _appDatabase = database;
    }

    public void rentEquipment(RentEquipment rentEquipment)
    {
        Person wypozyczajacy = getRenterToCheck(rentEquipment);
        Equipment doWypozyczenia = getEquipmentToCheck(rentEquipment);
        
        if (wypozyczajacy == null) return;
        if (doWypozyczenia == null || doWypozyczenia.Availability != EquipmentStatus.Dostepny) return;
        
        if (wypozyczajacy.LiczbaWypoznien >= wypozyczajacy.MaksymalnaLiczbaWypozyczen)
        {
            Console.WriteLine("Osiągnięto limit wypożyczeń"); 
            return;
        }

        wypozyczajacy.LiczbaWypoznien++;
        
        _appDatabase.AddToRentEquipmentList(rentEquipment);

        foreach (Equipment e in _appDatabase.Equipment)
        {
            if (e.Id == rentEquipment.EquipmentId)
            {
                e.Availability = EquipmentStatus.Wypozyczony;
                break;
            }
        }
    }

    public void returnEquipment(RentEquipment rentEquipment)
    {
        Person wypozyczajacy = getRenterToCheck(rentEquipment);
        
        if (wypozyczajacy == null) return;
        
        wypozyczajacy.LiczbaWypoznien--;
        
        rentEquipment.ActualReturnDate = DateOnly.FromDateTime(DateTime.Now);

        if (rentEquipment.ActualReturnDate > rentEquipment.PlannedReturnDate)
        {
            rentEquipment.KaraZaOpoznienie = (rentEquipment.ActualReturnDate.DayNumber -rentEquipment.PlannedReturnDate.DayNumber)*RentEquipment.DailyDelayPenalty;
        }
        
        foreach (Equipment e in _appDatabase.Equipment)
        {
            if (e.Id == rentEquipment.EquipmentId)
            {
                e.Availability = EquipmentStatus.Dostepny;
                break; 
            }
        }
    }
    
    
    public void endService(Service service)
    {

        foreach (Service e in _appDatabase.Services)
        {
            if (e.Id == service.Id)
            {
                e.ServiceEndDate = DateOnly.FromDateTime(DateTime.Now);
                break;
            }
        }
    }

    /*public void markService(Service service)
    {
        foreach (Equipment e in _appDatabase.Equipment)
        {
            if (e.Id == service.EquipmentId)
            {
                e.Availability = EquipmentStatus.Serwis;
                break;
            }
        }
    }*/
    
    public void addService(Service service)
    {
        _appDatabase.AddToServiceList(service);

        foreach (Service e in _appDatabase.Services)
        {
            if (e.Id == service.Id)
            {
                e.ServiceStartDate = DateOnly.FromDateTime(DateTime.Now);
                break;
            }
        }
    }
    
    public void markServiceEnd(Service service)
    {
        service.ServiceEndDate = DateOnly.FromDateTime(DateTime.Now);
        
        foreach (Equipment e in _appDatabase.Equipment)
        {
            if (e.Id == service.EquipmentId)
            {
                e.Availability = EquipmentStatus.Dostepny;
                break;
            }
        }
    }

    public Person getRenterToCheck(RentEquipment rentEquipment)
    {
        foreach (Person p in _appDatabase.Persons)
        {
            if (p.Id == rentEquipment.PersonId)
            {
                return p;
                
            }
        }

        return null;
    }
    
    public Equipment getEquipmentToCheck(RentEquipment rentEquipment)
    {
        foreach (Equipment e in _appDatabase.Equipment)
        {
            if (e.Id == rentEquipment.PersonId)
            {
                return e;
                
            }
        }

        return null;
    }
}