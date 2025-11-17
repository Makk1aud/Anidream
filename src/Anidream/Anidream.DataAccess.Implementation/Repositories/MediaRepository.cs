using Microsoft.EntityFrameworkCore;
using Anidream.Application.Contracts;
using Anidream.Application.Contracts.Media;
using Anidream.Application.Interfaces;
using Anidream.Domain.Entities;

namespace Anidream.DataAccess.Implementation;

internal class MediaRepository : BaseRepository<Media>, IMediaRepository
{
    public MediaRepository(AnidreamContext dbContext) : base(dbContext)
    { }

    public async Task<IEnumerable<Media>> GetMediasAsync(bool tracking = false, CancellationToken cancellationToken = default) =>
        await FindAll(tracking)
            .ToListAsync(cancellationToken: cancellationToken);

    public Task<PaginationList<Media>> GetMediasAsync(
        MediaFilter? filter,
        PaginationOptions paginationOptions,
        bool tracking = false,
        CancellationToken cancellationToken = default)
    {
        var filteredMedia = filter == null
            ? FindAll(tracking)
            : FindAll(tracking)
                .FilterByIsDeleted(filter.IsDeleted)
                .FilterByTitle(filter.Title)
                .FilterByAlias(filter.Alias)
                .FilterByReleaseDate(filter.MinReleaseDate, filter.MaxReleaseDate)
                .FilterByRating(filter.MinRating, filter.MaxRating)
                .FilterByGenreAlias(filter.GenresAliases);
        
        return Task.FromResult(filteredMedia.ToPaginationList(paginationOptions.PageNumber, paginationOptions.PageSize, filteredMedia.Count()));
    }

    public Task<Media?> GetMediaAsync(Guid id, bool tracking = false, bool isDeleted = false, CancellationToken cancellationToken = default) =>
        FindByExpression(x => x.IsDeleted == isDeleted && x.MediaId == id, tracking)
            .SingleOrDefaultAsync(cancellationToken: cancellationToken);

    public Task<Media?> GetMediaByAliasAsync(string alias, bool tracking = false, bool isDeleted = false, CancellationToken cancellationToken = default) =>
        FindByExpression(x => x.IsDeleted == isDeleted && x.Alias == alias, tracking)
            .SingleOrDefaultAsync(cancellationToken: cancellationToken);

    public async Task<Media> AddMediaAsync(Media media, CancellationToken cancellationToken = default) => 
        (await CreateAsync(media, cancellationToken)).Entity;

    public Task SetDeleteStatusMediaAsync(Media media, CancellationToken cancellationToken = default)
    {
        media.IsDeleted = true;
        return Task.CompletedTask;
    }

    public Task DeleteMediaAsync(Media media, CancellationToken cancellationToken = default)
    {
        Delete(media);
        return Task.CompletedTask;
    }
}