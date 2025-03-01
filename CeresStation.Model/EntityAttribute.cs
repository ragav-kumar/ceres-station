using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace CeresStation.Model;

[SuppressMessage("ReSharper", "ClassWithVirtualMembersNeverInherited.Global")]
[PrimaryKey(nameof(EntityId), nameof(DefinitionId))]
public class EntityAttribute
{
	[MaxLength(900)]
	public string Value { get; set; }
	
	public Guid DefinitionId { get; set; }
	public virtual EntityAttributeDefinition Definition { get; set; }
	
	public Guid EntityId { get; set; }
	public virtual EntityBase Entity { get; set; }
}
