namespace APBD_CW2.Models;

public class Employee : Person
{
    private static int _nextIdNumber = 1;
    
    public Employee(string imie, string nazwisko) : base(imie, nazwisko)
    {
        Id = $"e{_nextIdNumber++}";
    }

    public override int MaksymalnaLiczbaWypozyczen
    {
        get { return 5; }
    }
}