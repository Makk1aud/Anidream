namespace Anidream.Api.Application.Utils.Dtos;

public record DirectorDto
{
    public Guid DirectorId { get; init; }
    public string FullName { get; init; }
}