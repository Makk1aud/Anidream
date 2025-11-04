using Anidream.Application.Contracts.Director;
using Anidream.Application.Contracts.Genre;
using Anidream.Application.Contracts.Studio;

namespace Anidream.Application.Contracts.Media;

public record MediaResponse
{
    public Guid MediaId { get; init; }
    
    public string Title { get; init; }
    
    public string Alias { get; init; }
    
    public string Description { get; init; }
    
    public DateOnly ReleaseDate { get; init; }
    
    public double Rating { get; init; }
    
    public int TotalEpisodes { get; init; }
    
    public int CurrentEpisodes { get; init; }
    
    public int IsDeleted { get; init; }
    
    public int HasImage { get; init; }
    
    public IReadOnlyCollection<GenreDto> Genres { get; init; }
    
    public StudioDto Studio { get; init; }
    public DirectorResponse Director { get; init; }
}