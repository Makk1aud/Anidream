using System.ComponentModel.DataAnnotations;

namespace Anidream.Api.Domain.Entities;

public class Media
{
    [Key]
    public Guid MediaId { get; set; }
    
    [Required]
    [MaxLength(250)]
    public string Title { get; set; }
    
    [Required]
    [MaxLength(250)]
    public string Alias { get; set; }
    
    [Required]
    public string Description { get; set; }
    
    public Guid StudioId { get; set; }
    
    public Guid DirectorId { get; set; }
    
    public DateOnly ReleaseDate { get; set; }
    
    [Required] //max 10 min 10 default 0
    public double Rating { get; set; }
    
    public int TotalEpisodes { get; set; }
    
    public int CurrentEpisodes { get; set; }
}