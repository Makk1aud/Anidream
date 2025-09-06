using Anidream.Api.Application.UseCases.Services.Entities;
using Anidream.Api.Domain.Entities;

namespace Anidream.Api.Application.UseCases.Services.Interfaces;

public interface IMediaService
{
    public Task<IEnumerable<Media>> GetMediasAsync(
        bool tracking = false,
        CancellationToken cancellationToken = default);
    
    public Task<IEnumerable<Media>> GetMediasAsync(
        bool tracking = false,
        MediaFilter? filter = null,
        CancellationToken cancellationToken = default);
    
    public Task<Media?> GetMediaAsync(Guid id, CancellationToken cancellationToken = default);
    
    public Task<Media> AddMediaAsync(Media media, CancellationToken cancellationToken = default);
    
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    // public Task<Media> UpdateMediaAsync(Media media, CancellationToken cancellationToken = default);
}