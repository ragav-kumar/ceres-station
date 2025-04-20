using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace CeresStation.Model;

[SuppressMessage("ReSharper", "PropertyCanBeMadeInitOnly.Global")]
public class Reagent
{
	public Guid Id { get; set; }
	/// <summary>
	/// Amount processed per timestep
	/// </summary>
	public required float ProcessRate { get; set; }
	public required float Stockpile { get; set; }
	public required float Capacity { get; set; }
	
	public required Guid ResourceId { get; set; }
	public virtual Resource Resource { get; set; }
}
