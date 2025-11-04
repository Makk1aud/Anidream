using System.ComponentModel.DataAnnotations;

namespace Anidream.Domain.Entities;

public class Genre
{
    [Key]
    public Guid GenreId { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Title { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Alias { get; set; }
    
    public virtual ICollection<Media> Medias { get; set; } = new List<Media>();
}