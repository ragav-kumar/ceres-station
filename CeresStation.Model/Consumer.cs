using System.Diagnostics.CodeAnalysis;

namespace CeresStation.Model;

[SuppressMessage("ReSharper", "ClassWithVirtualMembersNeverInherited.Global")]
public class Consumer : EntityBase
{
    public required float ConsumptionRate { get; set; }
    public required float StandardDeviation { get; set; }
    public required float Stockpile { get; set; }
    public required float Capacity { get; set; }
    
    public required Guid ResourceId { get; set; }
    public virtual Resource Resource { get; set; }
}
