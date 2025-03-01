using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CeresStation.Model;

[PrimaryKey(nameof(Id))]
public abstract class EntityBase
{
	public Guid Id { get; set; }
	
	[MaxLength(100)]
	public required string Name { get; set; }
}
