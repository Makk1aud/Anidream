using Anidream.Application.Contracts.Studio;
using MediatR;

namespace Anidream.Application.UseCases.Handlers.Studio.GetListOfStudio;

public record GetListOfStudiosQuery : IRequest<IReadOnlyCollection<StudioResponse>>
{ }