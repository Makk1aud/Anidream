namespace Anidream.Application.Contracts.Media;

public record EpisodesResponse(string MediaAlias, IReadOnlyCollection<string> Episodes)
{
}