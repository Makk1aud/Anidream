using Anidream.Api.Application.Core;
using Anidream.Api.Application.UseCases.Extensions;
using Anidream.Api.Application.UseCases.Services.Entities;
using Anidream.Api.Application.UseCases.Services.Interfaces;
using Anidream.Api.Application.Utils.Exceptions;
using Anidream.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Anidream.Api.Application.UseCases.Services;

internal class MediaService : IMediaService
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

    public async Task<Media?> GetMediaAsync(Guid id, bool isDeleted = false, CancellationToken cancellationToken = default) =>
        (await GetMediasAsync(true, new MediaFilter {IsDeleted = isDeleted} ,cancellationToken))
        .FirstOrDefault(x => x.MediaId == id);

    public async Task<Media> AddMediaAsync(Media media, CancellationToken cancellationToken = default) => 
        (await _dbContext.Medias.AddAsync(media, cancellationToken)).Entity;

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
        _dbContext.SaveChangesAsync(cancellationToken);

    public async Task DeleteMediaAsync(Guid mediaId, CancellationToken cancellationToken = default)
    {
        var media = await GetMediaAsync(mediaId, false, cancellationToken);
        if(media == null)
            throw new MediaNotFoundException(mediaId.ToString());
        
        media.IsDeleted = true;
    }

    private static IEnumerable<Media> FilterMedia(IEnumerable<Media> items, MediaFilter? filter) =>
        filter is null 
            ? items
            : items
                .FilterByIsDeleted(filter.IsDeleted)
                .FilterByTitle(filter.Title)
                .FilterByAlias(filter.Alias)
                .FilterByReleaseDate(filter.MinReleaseDate, filter.MaxReleaseDate)
                .FilterByRating(filter.MinRating, filter.MaxRating);
    
}