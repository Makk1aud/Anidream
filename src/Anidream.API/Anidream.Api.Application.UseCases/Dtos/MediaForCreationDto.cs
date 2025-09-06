using System.ComponentModel.DataAnnotations;

namespace Anidream.Api.Application.Utils.Dtos;

public record MediaForCreationDto
{
    [Required]
    [MaxLength(250)]
    public string Title { get; init; }
    
    [Required]
    [MaxLength(250)]
    public string Alias { get; init; }
    
    [Required]
    public string Description { get; init; }
    
    public Guid StudioId { get; init; }
    
    public Guid DirectorId { get; init; }
    
    public DateOnly ReleaseDate { get; init; }
    
    [Required]
    [Range(0.0, 10.0)] //max 10 min 10 default 0
    public double Rating { get; init; }
    
    public int TotalEpisodes { get; init; }
    
    public int CurrentEpisodes { get; init; }
    
    public int IsDeleted { get; init; }
    
    public int HasImage { get; init; }
}