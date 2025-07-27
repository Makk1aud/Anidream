using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Media
{
    [Key]
    public Guid MediaId { get; set; }
    
    [Required]
    [MaxLength(150)]
    public string Title { get; set; }
}