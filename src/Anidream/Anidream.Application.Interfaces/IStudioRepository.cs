using Anidream.Domain.Entities;

namespace Anidream.Application.Interfaces;

public interface IStudioRepository
{
    public Task<IEnumerable<Studio>> GetStudiosAsync(
        bool tracking = false,
        CancellationToken cancellationToken = default);
    
    public Task<Studio?> GetStudioAsync(Guid id, bool tracking = false, CancellationToken cancellationToken = default);
    
    public Task<Studio> AddStudioAsync(Studio studio, CancellationToken cancellationToken = default);
    public Task<Studio> UpdateStudioAsync(Studio studio, CancellationToken cancellationToken = default);
    
    public Task DeleteStudioAsync(Studio studio, CancellationToken cancellationToken = default);
}