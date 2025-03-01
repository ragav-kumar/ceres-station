using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace CeresStation.Model;

[SuppressMessage("ReSharper", "ClassWithVirtualMembersNeverInherited.Global")]
[PrimaryKey(nameof(Id))]
public class Column
{
	public Guid Id { get; set; }
	public required EntityType EntityType { get; set; }
	public required FieldType FieldType { get; set; }
	
	[MaxLength(100)]
	public string? DisplayName { get; set; }

	/// <summary>
	/// Only used if FieldType == Attribute
	/// </summary>
	public Guid? AttributeDefinitionId { get; set; }

	/// <summary>
	/// Only used if FieldType == Model
	/// </summary>
	
	[MaxLength(100)]
	public string? FieldName { get; set; }

	public int Width { get; set; }
	public required int Order { get; set; }
}
