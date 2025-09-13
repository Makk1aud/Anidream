using Anidream.Api.Application.Core;
using Anidream.Api.Application.Shared;
using Anidream.Api.Application.Shared.Entities;
using Anidream.Api.Application.Utils.Dtos;
using MediatR;

namespace Anidream.Api.Application.UseCases.Handlers.Media.GetListOfMedia;

public class GetListOfMediaCommand : IRequest<PaginationList<MediaDto>>
{
    public PaginationOptions PaginationOptions {get; set;}   
    public MediaFilter? Filter {get; set;}
}