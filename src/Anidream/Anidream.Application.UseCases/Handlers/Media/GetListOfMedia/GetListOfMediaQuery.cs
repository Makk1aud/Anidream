using Anidream.Application.Contracts;
using Anidream.Application.Contracts.Media;
using MediatR;

namespace Anidream.Application.UseCases.Handlers.Media.GetListOfMedia;

public class GetListOfMediaQuery : IRequest<(IEnumerable<MediaResponse> Medias, PaginationMetadata Metadata)>
{
    public PaginationOptions PaginationOptions {get; set;}   
    public MediaFilter? Filter {get; set;}
}