using System.Diagnostics.CodeAnalysis;

namespace CeresStation.Model;

[SuppressMessage("ReSharper", "ClassWithVirtualMembersNeverInherited.Global")]
public class Processor : EntityBase
{
	public float TimeStep { get; set; }
	public IEnumerable<Reagent> Inputs { get; set; }
	public IEnumerable<Reagent> Outputs { get; set; }
}
