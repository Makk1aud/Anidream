namespace Anidream.Application.Interfaces;

public interface IRepositoryManager
{
    public IMediaRepository MediaRepository {get;}
    public IGenreRepository GenreRepository {get;}
    public IDirectorRepository DirectorRepository {get;}
    public IStudioRepository StudioRepository {get;}
    public IMediaGenreRepository MediaGenreRepository {get;}

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}