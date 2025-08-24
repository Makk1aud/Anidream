using Anidream.Api.Application.Core;
using Anidream.Api.Application.UseCases.Extensions;
using Anidream.Api.Application.UseCases.Services.Entities;
using Anidream.Api.Application.UseCases.Services.Interfaces;
using Anidream.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Anidream.Api.Application.UseCases.Services;

public class MediaService : IMediaService
{
    private readonly IDbContext _dbContext;

    public MediaService(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Media>> GetMediasAsync(bool tracking = false, CancellationToken cancellationToken = default) =>
        tracking
            ? await _dbContext
                .Medias
                .Include(x => x.Studio)
                .Include(x => x.Director)
                .ToListAsync(cancellationToken: cancellationToken)
            : await _dbContext
                .Medias
                .Include(x => x.Studio)
                .Include(x => x.Director)
                .AsNoTracking()
                .ToListAsync(cancellationToken);

    public async Task<IEnumerable<Media>> GetMediasAsync(
        bool tracking = false,
        MediaFilter? filter = null,
        CancellationToken cancellationToken = default) =>
            FilterMedia(await GetMediasAsync(tracking, cancellationToken), filter);
    
    private static IEnumerable<Media> FilterMedia(IEnumerable<Media> items, MediaFilter? filter) =>
        filter is null 
            ? items
            : items
                .FilterByTitle(filter.Title)
                .FilterByAlias(filter.Alias)
                .FilterByReleaseDate(filter.MinReleaseDate, filter.MaxReleaseDate)
                .FilterByRating(filter.MinRating, filter.MaxRating);
    
}