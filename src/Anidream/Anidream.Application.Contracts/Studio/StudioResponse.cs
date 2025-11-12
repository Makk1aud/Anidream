namespace Anidream.Application.Contracts.Studio;

public record StudioResponse
{
    public Guid StudioId { get; init; }
    public string Title { get; init; }
}