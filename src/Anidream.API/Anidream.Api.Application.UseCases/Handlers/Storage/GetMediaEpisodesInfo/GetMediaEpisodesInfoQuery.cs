using Anidream.Api.Application.Utils.Dtos;
using MediatR;

namespace Anidream.Api.Application.UseCases.Handlers.Storage.GetMediaEpisodesInfo;

public record GetMediaEpisodesInfoQuery(string MediaAlias) : IRequest<EpisodesInfoDto>
{
}