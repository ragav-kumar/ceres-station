using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace CeresStation.Model;

[SuppressMessage("ReSharper", "PropertyCanBeMadeInitOnly.Global")]
[PrimaryKey(nameof(Id))]
public abstract class EntityBase
{
	public Guid Id { get; set; }
	
	[MaxLength(100)]
	public required string Name { get; set; }
	
	public required Position Position { get; set; } 
}
