namespace Anidream.Application.Contracts.Studio;

public record StudioDto
{
    public Guid StudioId { get; init; }
    public string Title { get; init; }
}