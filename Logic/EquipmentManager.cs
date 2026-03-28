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
    }
}