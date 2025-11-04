using Anidream.Application.Contracts;
using Anidream.Application.Contracts.Media;
using MediatR;

namespace Anidream.Application.UseCases.Handlers.Media.UpdateMedia;

public class UpdateMediaCommand : IRequest<MediaResponse>
{
    public Guid MediaId { get; set; }
    public MediaForUpdateRequest Request { get; init; }
}