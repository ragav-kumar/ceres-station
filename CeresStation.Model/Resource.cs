using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CeresStation.Model;

[PrimaryKey(nameof(Id))]
public class Resource
{
    public Guid Id { get; set; }

    [MaxLength(100)]
    public required string Name { get; set; }
}
