namespace APBD_CW2.Models;

public class Projector : Equipment
{
    public string Resolution {get; set;}
    public string Brightness {get; set;}

    public Projector(string name, string data, string resolution, string brightness) : base(name, data)
    {
        Resolution = resolution;
        Brightness = brightness;
    }
}