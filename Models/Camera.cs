namespace APBD_CW2.Models;

public class Camera : Equipment
{
    public int SensorResolution {get; set;}
    public int Iso {get; set;}

    public Camera(string name, string data, int sensorResolution, int iso) : base(name, data)
    {
        SensorResolution = sensorResolution;
        Iso = iso;
    }
}