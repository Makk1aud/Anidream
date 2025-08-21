using Anidream.Api.Application.Core;
using Anidream.Api.Application.UseCases.Services;
using Anidream.Api.Application.Utils.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Anidream.Api.Application.UseCases.Handlers.Media.GetListOfMedia;

public class GetListOfMediaCommandHandler : IRequestHandler<GetListOfMediaCommand, PaginationList<MediaDto>>
{
    private readonly IDbContext _dbContext;

    public GetListOfMediaCommandHandler(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<PaginationList<MediaDto>> Handle(GetListOfMediaCommand request, CancellationToken cancellationToken)
    {
        var medias = await _dbContext.Medias.Include(x => x.Studio).ToListAsync(cancellationToken);
        var mediasDto = medias.Select(x => new MediaDto
        {
            MediaId = x.MediaId,
            Title = x.Title,
            Alias = x.Alias,
            CurrentEpisodes = x.CurrentEpisodes,
            Description = x.Description,
            Director = x.Director,
            Rating = x.Rating,
            ReleaseDate = x.ReleaseDate,
            //Studio = x.Studio,
            TotalEpisodes = x.TotalEpisodes
        }).ToList();
        
        
        return new PaginationList<MediaDto>(mediasDto, request.PaginationOptions.PageNumber, request.PaginationOptions.PageSize);
    }
}