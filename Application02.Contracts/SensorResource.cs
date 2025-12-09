namespace Application02.Contracts;

public class SensorResource
{
    public string DevEui { get; set; }
    public string SensorId { get; set; }
    public DateTime TimeStamp { get; set; }
    public bool Occupied { get; set; }
}