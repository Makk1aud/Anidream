using Anidream.Application.Contracts;
using Anidream.Application.Contracts.Media;
using Anidream.Domain.Entities;

namespace Anidream.Application.Interfaces;

public interface IMediaRepository
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
    
    public Task DeleteMediaAsync(Media media, CancellationToken cancellationToken = default);
}