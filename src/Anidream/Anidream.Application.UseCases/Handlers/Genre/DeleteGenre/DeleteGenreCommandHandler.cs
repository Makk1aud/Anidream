using Anidream.Application.Exceptions;
using Anidream.Application.Interfaces;
using MediatR;

namespace Anidream.Application.UseCases.Handlers.Genre.DeleteGenre;

internal sealed class DeleteGenreCommandHandler : IRequestHandler<DeleteGenreCommand>
{
    private readonly IRepositoryManager _repositoryManager;

    public DeleteGenreCommandHandler(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }
    
    public async Task Handle(DeleteGenreCommand request, CancellationToken cancellationToken)
    {
        var genre = await _repositoryManager.GenreRepository.GetGenreAsync(request.GenreId, cancellationToken: cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Genre), request.GenreId); 
        await _repositoryManager.GenreRepository.DeleteGenreAsync(genre, cancellationToken: cancellationToken);
        await _repositoryManager.SaveChangesAsync(cancellationToken);
    }
}