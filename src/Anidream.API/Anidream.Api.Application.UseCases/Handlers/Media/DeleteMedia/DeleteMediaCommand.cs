using MediatR;

namespace Anidream.Api.Application.Utils.Handlers.Media.DeleteMedia;

public class DeleteMediaCommand : IRequest
{
    public Guid MediaId { get; set; }
}