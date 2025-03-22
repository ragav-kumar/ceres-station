using System.Diagnostics.CodeAnalysis;

namespace CeresStation.Model;

/// <summary>
/// Generates resources at a fluctuating rate. Resources are stockpiled.
/// Generation stops once stockpile is full
/// </summary>

[SuppressMessage("ReSharper", "ClassWithVirtualMembersNeverInherited.Global")]
[SuppressMessage("ReSharper", "PropertyCanBeMadeInitOnly.Global")]
public class Extractor : EntityBase
{
    public required float ExtractionRate { get; set; }
    public required float StandardDeviation { get; set; }
    public required float Stockpile { get; set; }
    public required float Capacity { get; set; }

    public required Guid ResourceId { get; set; }
    public virtual Resource Resource { get; set; }
}
