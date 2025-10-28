using Anidream.Api.Domain.Entities;

namespace Anidream.Api.Application.Utils.Dtos;

//Todo: Добавить список жанров
public record MediaDto
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
    public DirectorDto Director { get; init; }
}