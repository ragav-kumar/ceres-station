using Microsoft.EntityFrameworkCore;

namespace CeresStation.Model;

[PrimaryKey(nameof(Id))]
public class Reagent
{
	public Guid Id { get; set; }
	public float Count { get; set; }
	public float StockpileCapacity { get; set; }
	
	public Guid ResourceId { get; set; }
	public virtual Resource Resource { get; set; }
}
