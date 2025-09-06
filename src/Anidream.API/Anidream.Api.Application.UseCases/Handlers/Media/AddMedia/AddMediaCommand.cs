using Anidream.Api.Application.Utils.Dtos;
using MediatR;

namespace Anidream.Api.Application.UseCases.Handlers.Media.AddMedia;

public class AddMediaCommand : IRequest<MediaDto>
{
    public MediaForCreationDto MediaForCreationDto { get; set; }
}