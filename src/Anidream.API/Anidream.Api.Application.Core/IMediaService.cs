using Anidream.Api.Application.Shared.Entities;
using Anidream.Api.Domain.Entities;

namespace Anidream.Api.Application.Core;

public interface IMediaService
{
    public Task<IEnumerable<Media>> GetMediasAsync(
        bool tracking = false,
        CancellationToken cancellationToken = default);
    
    public Task<IEnumerable<Media>> GetMediasAsync(
        bool tracking = false,
        MediaFilter? filter = null,
        CancellationToken cancellationToken = default);
    
    public Task<Media?> GetMediaAsync(Guid id, bool isDeleted = false, CancellationToken cancellationToken = default);
    
    public Task<Media> AddMediaAsync(Media media, CancellationToken cancellationToken = default);
    
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    
    public Task DeleteMediaAsync(Guid mediaId, CancellationToken cancellationToken = default);
}