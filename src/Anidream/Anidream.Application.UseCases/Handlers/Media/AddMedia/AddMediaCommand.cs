using Anidream.Application.Contracts;
using Anidream.Application.Contracts.Media;
using MediatR;

namespace Anidream.Application.UseCases.Handlers.Media.AddMedia;

public class AddMediaCommand : IRequest<MediaResponse>
{
    public MediaForCreationRequest MediaForCreationRequest { get; set; }
}