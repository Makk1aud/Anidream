using Anidream.Application;
using Anidream.Application.Contracts;
using Anidream.Application.Contracts.Media;
using Anidream.Application.Interfaces;
using Anidream.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Anidream.DataAccess.Implementation;

//Todo: можно вынести в абстрактный класс метод SaveChanges, если будут добавлены еще репозитории для работы с БД
//Todo: Для работы с отслеживанием объектов БД, можно выделить базовый класс, который через Set<T> будет обеспечиваться возможность отслеживания 
//Todo: в базовый класс добавить метод для работы с условиями в запросе, как в первой реализации, которую я делал

//Это не сервис а репозиторий уже больше, в нем нет логики чтобы называть его сервисом
internal class MediaRepository : BaseRepository<Media>, IMediaRepository
{
    public MediaRepository(AnidreamContext dbContext) : base(dbContext)
    { }

    public async Task<IEnumerable<Media>> GetMediasAsync(bool tracking = false, CancellationToken cancellationToken = default) =>
        await FindAll(tracking)
            .ToListAsync(cancellationToken: cancellationToken);

    public async Task<PaginationList<Media>> GetMediasAsync(
        MediaFilter? filter,
        PaginationOptions paginationOptions,
        bool tracking = false,
        CancellationToken cancellationToken = default)
    {
        var totalCount = await FindAll(false)
            .FilterByIsDeleted(filter?.IsDeleted)
            .CountAsync(cancellationToken: cancellationToken);
        return filter == null 
            ? FindAll(tracking).ToPaginationList(paginationOptions.PageNumber, paginationOptions.PageSize, totalCount)
            : FindAll(tracking)
                .FilterByIsDeleted(filter.IsDeleted)
                .FilterByTitle(filter.Title)
                .FilterByAlias(filter.Alias)
                .FilterByReleaseDate(filter.MinReleaseDate, filter.MaxReleaseDate)
                .FilterByRating(filter.MinRating, filter.MaxRating)
                .FilterByGenreAlias(filter.GenresAliases)
                .ToPaginationList(paginationOptions.PageNumber, paginationOptions.PageSize, totalCount);
    }

    public Task<Media?> GetMediaAsync(Guid id, bool tracking = false, bool isDeleted = false, CancellationToken cancellationToken = default) =>
        FindByExpression(x => x.IsDeleted == isDeleted && x.MediaId == id, tracking)
            .SingleOrDefaultAsync(cancellationToken: cancellationToken);

    public Task<Media?> GetMediaByAliasAsync(string alias, bool tracking = false, bool isDeleted = false, CancellationToken cancellationToken = default) =>
        FindByExpression(x => x.IsDeleted == isDeleted && x.Alias == alias, tracking)
            .SingleOrDefaultAsync(cancellationToken: cancellationToken);

    public async Task<Media> AddMediaAsync(Media media, CancellationToken cancellationToken = default) => 
        (await CreateAsync(media, cancellationToken)).Entity;

    public Task DeleteMediaAsync(Media media, CancellationToken cancellationToken = default)
    {
        media.IsDeleted = true;
        return Task.CompletedTask;
    }
}