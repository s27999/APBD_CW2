namespace APBD_CW2.Models;

public class Student : Person
{
    private static int _nextIdNumber = 1;
    
    public Student(string imie, string nazwisko) : base(imie, nazwisko)
    {
        Id = $"s{_nextIdNumber++}";
    }

    public override int MaksymalnaLiczbaWypozyczen
    {
        get { return 2; }
    }
}