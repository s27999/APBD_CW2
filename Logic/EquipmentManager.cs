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

    public void markService(Service service)
    {
        foreach (Equipment e in _appDatabase.Equipment)
        {
            if (e.Id == service.EquipmentId)
            {
                e.Availability = EquipmentStatus.Serwis;
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
}