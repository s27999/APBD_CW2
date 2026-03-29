using APBD_CW2.Database;
using APBD_CW2.Logic;

namespace APBD_CW2.UI;

class Program
{
    static void Main(string[] args)
    {
        AppDatabase appDatabase = new AppDatabase();
        EquipmentManager _equipmentManager = new EquipmentManager(appDatabase);
        DataManager _dataManager = new DataManager(appDatabase);
        DatabaseManager _databaseManager = new DatabaseManager(appDatabase);
        
        ConsoleUI _consoleUI = new ConsoleUI(_equipmentManager, _dataManager, _databaseManager);
        
        _consoleUI.Start();
    }
}
