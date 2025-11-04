using System.ComponentModel.DataAnnotations;
using Anidream.Application.Contracts.Genre;

namespace Anidream.Application.Contracts.Media;

public record MediaForCreationRequest
{
    [Required]
    [MaxLength(250)]
    public string Title { get; init; }
    
    [Required]
    [MaxLength(250)]
    public string Alias { get; init; }
    
    [Required]
    public string Description { get; init; }
    
    public Guid? StudioId { get; init; }
    
    public Guid? DirectorId { get; init; }
    
    [Required]
    public DateOnly? ReleaseDate { get; init; }
    
    [Range(0.0, 10.0)] //max 10 min 10 default 0
    public double Rating { get; init; }
    
    [Required]
    public IReadOnlyList<GenreDto>? Genres { get; init; }
    
    public int? TotalEpisodes { get; init; }
    
    public int? CurrentEpisodes { get; init; }
}