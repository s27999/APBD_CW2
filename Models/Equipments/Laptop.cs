namespace APBD_CW2.Models;

public class Laptop : Equipment
{
    public string Procesor {get; set;}
    public string KartaGraficzna {get; set;}

    public Laptop(string name, string data, string procesor, string kartaGraficzna) : base(name, data)
    {
        Procesor = procesor;
        KartaGraficzna = kartaGraficzna;
    }
}