using Anidream.Api.Application.Shared.Entities;
using Anidream.Api.Application.Utils.Dtos;
using MediatR;

namespace Anidream.Api.Application.UseCases.Handlers.Media.GetListOfMedia;

public class GetListOfMediaQuery : IRequest<(IEnumerable<MediaDto> Medias, PaginationMetadata Metadata)>
{
    public PaginationOptions PaginationOptions {get; set;}   
    public MediaFilter? Filter {get; set;}
}