using System.ComponentModel.DataAnnotations;

namespace Anidream.Domain.Entities;

public class Director
{
    [Key]
    public Guid DirectorId { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string FullName { get; set; }
    
    public virtual ICollection<Media> Medias { get; set; } = new List<Media>();
}