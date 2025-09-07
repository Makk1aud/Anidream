using Anidream.Api.Application.Utils.Dtos;
using MediatR;

namespace Anidream.Api.Application.Utils.Handlers.Media.UpdateMedia;

public class UpdateMediaCommand : IRequest<MediaDto>
{
    public Guid MediaId { get; set; }
    public MediaForUpdateDto Dto { get; init; }
}