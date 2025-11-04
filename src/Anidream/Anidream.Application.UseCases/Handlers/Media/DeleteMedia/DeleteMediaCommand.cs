using MediatR;

namespace Anidream.Application.UseCases.Handlers.Media.DeleteMedia;

public class DeleteMediaCommand : IRequest
{
    public Guid MediaId { get; set; }
}