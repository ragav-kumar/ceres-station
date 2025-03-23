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
    public float ExtractionRate { get; set; }
    public float StandardDeviation { get; set; }
    public float Stockpile { get; set; }
    public float Capacity { get; set; }

    public Guid ResourceId { get; set; }
    public virtual Resource Resource { get; set; }
}