using System.ComponentModel.DataAnnotations;

namespace Anidream.Api.Domain.Entities;

public class Studio
{
    [Key]
    public Guid StudioId { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Title { get; set; }
}