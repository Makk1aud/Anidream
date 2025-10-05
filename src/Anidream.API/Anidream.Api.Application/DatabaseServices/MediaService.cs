using Anidream.Api.Application.Core;
using Anidream.Api.Application.Extensions;
using Anidream.Api.Application.Shared.Entities;
using Anidream.Api.Application.Shared.Exceptions;
using Anidream.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Anidream.Api.Application.DatabaseServices;

//Todo: можно вынести в абстрактный класс метод SaveChanges, если будут добавлены еще репозитории для работы с БД
//Todo: Для работы с отслеживанием объектов БД, можно выделить базовый класс, который через Set<T> будет обеспечиваться возможность отслеживания 
//Todo: в базовый класс добавить метод для работы с условиями в запросе, как в первой реализации, которую я делал
internal class MediaService : IMediaService
{
    private readonly IDbContext _dbContext;

    public MediaService(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Media>> GetMediasAsync(bool tracking = false, CancellationToken cancellationToken = default) =>
        tracking
            ? await GetMedias()
                .ToListAsync(cancellationToken: cancellationToken)
            : await GetMedias()
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

    public async Task<Media?> GetMediaByAliasAsync(string alias, bool isDeleted = false, CancellationToken cancellationToken = default) =>
        (await GetMediasAsync(true, new MediaFilter {IsDeleted = isDeleted} ,cancellationToken))
        .FirstOrDefault(x => x.Alias == alias);

    public async Task<Media> AddMediaAsync(Media media, CancellationToken cancellationToken = default) => 
        (await _dbContext.Medias.AddAsync(media, cancellationToken)).Entity;

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
        _dbContext.SaveChangesAsync(cancellationToken);

    public async Task DeleteMediaAsync(Guid mediaId, CancellationToken cancellationToken = default)
    {
        var media = await GetMediaAsync(mediaId, false, cancellationToken);
        if(media == null)
            throw new MediaNotFoundException(mediaId);
        
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
                .FilterByRating(filter.MinRating, filter.MaxRating)
                .FilterByGenreAlias(filter.GenresAliases);

    private IQueryable<Media> GetMedias() => _dbContext
        .Medias
        .Include(x => x.Studio)
        .Include(x => x.Director)
        //.Include(x => x.MediaGenres)
        .Include(x => x.Genres);
}