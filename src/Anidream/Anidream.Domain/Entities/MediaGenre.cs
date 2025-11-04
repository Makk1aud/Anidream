using System.ComponentModel.DataAnnotations;

namespace Anidream.Domain.Entities;

public class MediaGenre
{
    [Key]
    public Guid MediaId { get; set; }
    
    [Key]
    public Guid GenreId { get; set; }
    
    public virtual Media Media { get; set; } 
    public virtual Genre Genre { get; set; }
}