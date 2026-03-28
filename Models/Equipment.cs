namespace APBD_CW2.Models;

public enum EquipmentStatus
{
    Dostepny,
    Wypozyczony,
    Serwis
}

public abstract class Equipment
{
    private static int _nextIdNumber = 1;
    private static int _dailyDelayPenalty = 10;
    
    public string Id { get; protected set; }
    public string Name { get; set; }
    public EquipmentStatus Availability { get; set; }
    public string Data { get; set; }

    public Equipment(string name, string data)
    {
        Name = name;
        Data = data;
        
        Availability = EquipmentStatus.Dostepny;
        Id = $"{_nextIdNumber++}";
    }
}