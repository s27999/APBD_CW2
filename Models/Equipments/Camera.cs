namespace APBD_CW2.Models;

public class Camera : Equipment
{
    public string SensorResolution {get; set;}
    public string Iso {get; set;}

    public Camera(string name, string data, string sensorResolution, string iso) : base(name, data)
    {
        SensorResolution = sensorResolution;
        Iso = iso;
    }
}