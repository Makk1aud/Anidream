using Anidream.Application.Interfaces;

namespace Anidream.DataAccess.Implementation;

public class RepositoryManager : IRepositoryManager
{
    private readonly AnidreamContext _context;
    private readonly Lazy<IMediaRepository> _mediaRepository;
    private readonly Lazy<IGenreRepository> _genreRepository;
    private readonly Lazy<IDirectorRepository> _directorRepository;
    private readonly Lazy<IStudioRepository> _studioRepository;
    private readonly Lazy<IMediaGenreRepository> _mediaGenreRepository;

    public RepositoryManager(AnidreamContext context)
    {
        _context = context;
        _genreRepository = new Lazy<IGenreRepository>(() => new GenreRepository(context));
        _mediaRepository = new Lazy<IMediaRepository>(() => new MediaRepository(context));
        _directorRepository = new Lazy<IDirectorRepository>(() => new DirectorRepository(context));
        _studioRepository = new Lazy<IStudioRepository>(() => new StudioRepository(context));
        _mediaGenreRepository = new Lazy<IMediaGenreRepository>(() => new MediaGenreRepository(context));
    }
    
    public IMediaRepository MediaRepository => _mediaRepository.Value;
    
    public IGenreRepository GenreRepository => _genreRepository.Value;
    public IDirectorRepository DirectorRepository => _directorRepository.Value;
    public IStudioRepository StudioRepository => _studioRepository.Value;
    public IMediaGenreRepository MediaGenreRepository => _mediaGenreRepository.Value;

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
        _context.SaveChangesAsync(cancellationToken);
}