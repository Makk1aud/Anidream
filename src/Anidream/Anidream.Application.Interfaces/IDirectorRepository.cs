using Anidream.Domain.Entities;

namespace Anidream.Application.Interfaces;

public interface IDirectorRepository
{
    public Task<IEnumerable<Director>> GetDirectorsAsync(
        bool tracking = false,
        CancellationToken cancellationToken = default);
    
    public Task<Director?> GetDirectorAsync(Guid id, bool tracking = false, CancellationToken cancellationToken = default);
    
    public Task<Director> AddDirectorAsync(Director director, CancellationToken cancellationToken = default);
    
    public Task DeleteDirectorAsync(Director director, CancellationToken cancellationToken = default);
}