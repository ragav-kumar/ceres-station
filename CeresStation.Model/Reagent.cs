using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace CeresStation.Model;

[SuppressMessage("ReSharper", "PropertyCanBeMadeInitOnly.Global")]
public class Reagent
{
	public Guid Id { get; set; }
	public required float Count { get; set; }
	public required float StockpileCapacity { get; set; }
	
	public required Guid ResourceId { get; set; }
	public virtual Resource Resource { get; set; }
}
