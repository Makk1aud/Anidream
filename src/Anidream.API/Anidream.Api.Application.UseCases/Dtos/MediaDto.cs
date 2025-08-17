using Anidream.Api.Domain.Entities;

namespace Anidream.Api.Application.Utils.Dtos;

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
    
    public virtual Studio Studio { get; init; }
    public virtual Director Director { get; init; }
}