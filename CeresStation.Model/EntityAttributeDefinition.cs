﻿using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace CeresStation.Model;

[SuppressMessage("ReSharper", "ClassWithVirtualMembersNeverInherited.Global")]
[SuppressMessage("ReSharper", "PropertyCanBeMadeInitOnly.Global")]
[PrimaryKey(nameof(Id))]
public class EntityAttributeDefinition
{
	public Guid Id { get; set; }
	
	[MaxLength(100)]
	public required string Name { get; set; }
	public EntityType EntityType { get; set; }
	public AttributeDataType DataType { get; set; }
}
