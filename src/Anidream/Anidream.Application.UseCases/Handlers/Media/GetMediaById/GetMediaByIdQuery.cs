using Anidream.Application.Contracts;
using Anidream.Application.Contracts.Media;
using MediatR;

namespace Anidream.Application.UseCases.Handlers.Media.GetMediaById;

public class GetMediaByIdQuery : IRequest<MediaResponse>
{
    public Guid MediaId { get; init; }
}