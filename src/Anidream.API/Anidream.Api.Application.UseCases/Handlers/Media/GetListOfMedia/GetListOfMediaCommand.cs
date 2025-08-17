using Anidream.Api.Application.UseCases.Options;
using Anidream.Api.Application.Utils.Dtos;
using MediatR;

namespace Anidream.Api.Application.UseCases.Handlers.Media.GetListOfMedia;

public class GetListOfMediaCommand : IRequest<IReadOnlyCollection<MediaDto>>
{
    public PaginationOptions PaginationOptions {get; set;}   
}