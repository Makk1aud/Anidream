namespace Anidream.Application.Contracts.Director;

public record DirectorResponse
{
    public Guid DirectorId { get; init; }
    public string FullName { get; init; }
}