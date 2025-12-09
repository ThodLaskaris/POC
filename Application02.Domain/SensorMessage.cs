using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application02.Domain;

[Table("Sensors")]
public class SensorMessage
{
    [Key]
    public Guid Id { get; set; }
    public string DevEui { get; set; }
    public string SensorId { get; set; }
    public DateTime TimeStamp { get; set; }
    public bool Occupied { get; set; }
    public string? RawData { get; set; }
}