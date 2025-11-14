using Anidream.Application.Contracts.Studio;
using MediatR;

namespace Anidream.Application.UseCases.Handlers.Studio.UpdateStudio;

public record UpdateStudioCommand(Guid StudioId, StudioRequest Request) : IRequest<StudioResponse>
{ }