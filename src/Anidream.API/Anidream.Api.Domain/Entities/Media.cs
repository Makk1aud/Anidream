using System.ComponentModel.DataAnnotations;

namespace Anidream.Api.Domain.Entities;

//TODO: Добавление жанра надо делать через enum + отдельная таблица id + enum
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
    
    public Guid? StudioId { get; set; }
    
    public Guid? DirectorId { get; set; }
    
    [Required]
    public DateOnly ReleaseDate { get; set; }
    
    [Required]
    [Range(0.0, 10.0)] //max 10 min 10 default 0
    public double Rating { get; set; }
    
    public int? TotalEpisodes { get; set; }
    
    public int? CurrentEpisodes { get; set; }

    public bool IsDeleted { get; set; } = false;
    
    public bool HasImage { get; set; } =  false;
    
    public virtual Studio Studio { get; set; } 
    public virtual Director Director { get; set; }

    public Media()
    {
        Rating = 0;
    }
}