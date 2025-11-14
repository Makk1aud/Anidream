using Anidream.Application.Contracts.Studio;
using MediatR;

namespace Anidream.Application.UseCases.Handlers.Studio.GetStudioById;

public record GetStudioByIdQuery(Guid StudioId) : IRequest<StudioResponse>
{ }