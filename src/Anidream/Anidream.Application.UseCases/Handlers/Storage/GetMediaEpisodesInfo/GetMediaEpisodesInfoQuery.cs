using Anidream.Application.Contracts;
using Anidream.Application.Contracts.Media;
using MediatR;

namespace Anidream.Application.UseCases.Handlers.Storage.GetMediaEpisodesInfo;

public record GetMediaEpisodesInfoQuery(string MediaAlias) : IRequest<EpisodesResponse>
{
}