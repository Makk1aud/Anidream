
namespace Anidream.Application.Interfaces;

public interface IMediaGenreRepository
{
    public Task UpdateMediaGenres(Guid mediaId, IReadOnlyCollection<Guid> genresId, CancellationToken cancellationToken = default);
}