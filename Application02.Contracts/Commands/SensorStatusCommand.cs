namespace Application02.Contracts.Commands;

public class SensorStatusCommand : SensorResource
{
    public string? RawData { get; set; }
}