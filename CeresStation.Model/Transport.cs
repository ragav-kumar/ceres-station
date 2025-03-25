using System.Diagnostics.CodeAnalysis;

namespace CeresStation.Model;

[SuppressMessage("ReSharper", "ClassWithVirtualMembersNeverInherited.Global")]
[SuppressMessage("ReSharper", "PropertyCanBeMadeInitOnly.Global")]
public class Transport : EntityBase
{
    public required float TripTimeStandardDeviation { get; set; }
    public required float CurrentCargo { get; set; }
    public required float Capacity { get; set; }
    
    
    public required Guid SourceId { get; set; }
    public virtual EntityBase Source { get; set; }
    public required Guid DestinationId { get; set; }
    public virtual EntityBase Destination { get; set; }
    public required Guid ResourceId { get; set; }
    public virtual Resource Resource { get; set; }
}
