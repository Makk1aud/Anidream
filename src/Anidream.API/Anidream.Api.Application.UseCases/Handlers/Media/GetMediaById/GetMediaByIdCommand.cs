using Anidream.Api.Application.Utils.Dtos;
using MediatR;

namespace Anidream.Api.Application.Utils.Handlers.Media.GetMediaById;

public class GetMediaByIdCommand : IRequest<MediaDto>
{
    public Guid MediaId { get; init; }
}