using Anidream.Api.Application.Shared;
using Anidream.Api.Application.Shared.Entities;
using Anidream.Api.Domain.Entities;

namespace Anidream.Api.Application.Core;

public interface IMediaService
{
    public Task<IEnumerable<Media>> GetMediasAsync(
        bool tracking = false,
        CancellationToken cancellationToken = default);
    
    public Task<PaginationList<Media>> GetMediasAsync(
        MediaFilter? filter,
        PaginationOptions paginationOptions,
        bool tracking = false,
        CancellationToken cancellationToken = default);
    
    public Task<Media?> GetMediaAsync(Guid id, bool tracking = false, bool isDeleted = false, CancellationToken cancellationToken = default);
    public Task<Media?> GetMediaByAliasAsync(string alias, bool tracking = false, bool isDeleted = false, CancellationToken cancellationToken = default);
    
    public Task<Media> AddMediaAsync(Media media, CancellationToken cancellationToken = default);
    
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    
    public Task DeleteMediaAsync(Media media, CancellationToken cancellationToken = default);
}