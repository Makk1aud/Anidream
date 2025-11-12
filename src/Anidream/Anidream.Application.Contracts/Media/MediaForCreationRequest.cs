using System.ComponentModel.DataAnnotations;
using Anidream.Application.Contracts.Genre;

namespace Anidream.Application.Contracts.Media;

public record MediaForCreationRequest
{
    public string Title { get; init; } = string.Empty;
    
    public string Alias { get; init; } = string.Empty;
    
    public string Description { get; init; } = string.Empty;
    
    public Guid? StudioId { get; init; }
    
    public Guid? DirectorId { get; init; }
    
    public DateOnly? ReleaseDate { get; init; }
    
    //max 10 min 10 default 0
    public double Rating { get; init; }
    
    public IReadOnlyCollection<Guid> GenresIds { get; init; }
    
    public int? TotalEpisodes { get; init; }
    
    public int? CurrentEpisodes { get; init; }
}