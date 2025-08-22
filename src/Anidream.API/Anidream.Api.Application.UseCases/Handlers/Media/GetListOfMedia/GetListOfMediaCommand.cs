using Anidream.Api.Application.Core;
using Anidream.Api.Application.UseCases.Handlers.Media.GetListOfMedia.Entities;
using Anidream.Api.Application.UseCases.Services;
using Anidream.Api.Application.Utils.Dtos;
using MediatR;

namespace Anidream.Api.Application.UseCases.Handlers.Media.GetListOfMedia;

public class GetListOfMediaCommand : IRequest<PaginationList<MediaDto>>
{
    public PaginationOptions PaginationOptions {get; set;}   
}