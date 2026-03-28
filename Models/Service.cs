namespace APBD_CW2.Models;

public class Service
{
    public string EquipmentId {get; set;}
    public string ServiceDescription {get; set;}
    public DateOnly ServiceStartDate {get; set;}
    public DateOnly ServiceEndDate {get; set;}


    public Service(Equipment equipment, String serviceDescription)
    {
        EquipmentId = equipment.Id;
        ServiceDescription = serviceDescription;
        ServiceStartDate = DateOnly.FromDateTime(DateTime.Now);
    }
}