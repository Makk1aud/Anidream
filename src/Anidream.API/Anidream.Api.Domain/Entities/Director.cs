using System.ComponentModel.DataAnnotations;

namespace Anidream.Api.Domain.Entities;

public class Director
{
    [Key]
    public Guid DirectorId { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string FullName { get; set; }
}