namespace Anidream.Api.Application.Utils.Dtos;

public record StudioDto
{
    public Guid StudioId { get; init; }
    public string Title { get; init; }
}