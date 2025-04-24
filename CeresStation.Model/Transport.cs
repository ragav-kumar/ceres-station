using System.Diagnostics.CodeAnalysis;

namespace CeresStation.Model;

[SuppressMessage("ReSharper", "ClassWithVirtualMembersNeverInherited.Global")]
[SuppressMessage("ReSharper", "PropertyCanBeMadeInitOnly.Global")]
public class Transport : EntityBase
{
    public required float Acceleration { get; set; }
    public required float StandardDeviation { get; set; }
    
    public required float Stockpile { get; set; }
    public required float Capacity { get; set; }
    
    public Guid? CargoTypeId { get; set; }
    public virtual Resource? CargoType { get; set; }
    
    public required Guid RouteId { get; set; }
    public virtual TransportRoute Route { get; set; }
    public required int NextWaypointIndex { get; set; }
}
