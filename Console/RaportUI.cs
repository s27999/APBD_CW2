using APBD_CW2.Logic;

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
}