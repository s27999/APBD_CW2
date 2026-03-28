namespace APBD_CW2.Models;

public class RentEquipment
{
    public string PersonId { get; private set; }
    public string EquipmentId { get; private set; }
    
    public DateOnly RentDate {get; set;}
    public DateOnly PlannedReturnDate {get; set;}

    public RentEquipment(Person person, Equipment equipment, DateOnly rentDate, DateOnly plannedReturnDate)
    {
        PersonId = person.Id;
        EquipmentId = equipment.Id;
       
        RentDate = rentDate;
        PlannedReturnDate = plannedReturnDate;
    }
    
}