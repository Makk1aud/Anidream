using Anidream.Application.Interfaces;
using Anidream.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Anidream.DataAccess.Implementation;

public class MediaGenreRepository : BaseRepository<MediaGenre>, IMediaGenreRepository
{
    public MediaGenreRepository(AnidreamContext dbContext) : base(dbContext)
    { }

    public async Task UpdateMediaGenres(Guid mediaId, IReadOnlyCollection<Guid> genresId, CancellationToken cancellationToken = default)
    {
        var mediaGenres = await FindByExpression(x => x.MediaId == mediaId, true).ToListAsync(cancellationToken: cancellationToken);
        foreach (var mediaGenre in mediaGenres)
            Delete(mediaGenre);
        
        foreach (var genre in genresId)
            await CreateAsync(new MediaGenre { MediaId = mediaId, GenreId = genre }, cancellationToken);
    }
}