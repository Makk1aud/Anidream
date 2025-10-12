namespace Anidream.Api.Application.Utils.Dtos;

public record EpisodesInfoDto(string MediaAlias, IReadOnlyCollection<string> Episodes)
{
}