using Anidream.Application.Contracts.Studio;
using MediatR;

namespace Anidream.Application.UseCases.Handlers.Studio.AddStudio;

public record AddStudioCommand(StudioRequest Request) : IRequest<StudioResponse>
{ }