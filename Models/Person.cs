namespace APBD_CW2.Models;

public abstract class Person
{
    public string Id { get; protected set; }
    public string Name { get; set; }
    public string LastName { get; set; }

    public Person(string name, string lastName)
    {
        Name = name;
        LastName = lastName;
    }
    
    public abstract int MaksymalnaLiczbaWypozyczen { get; }
}