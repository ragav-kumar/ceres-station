using System.Diagnostics.CodeAnalysis;

namespace CeresStation.Model;

[SuppressMessage("ReSharper", "ClassWithVirtualMembersNeverInherited.Global")]
[SuppressMessage("ReSharper", "PropertyCanBeMadeInitOnly.Global")]
public class Processor : EntityBase
{
	public float TimeStep { get; set; }
	public virtual ICollection<Reagent> Inputs { get; set; }
	public virtual ICollection<Reagent> Outputs { get; set; }
}
