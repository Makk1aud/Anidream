using Anidream.Application.Exceptions;
using Anidream.Application.Interfaces;
using MediatR;

namespace Anidream.Application.UseCases.Handlers.Director.DeleteDirector;

internal sealed class DeleteDirectorCommandHandler : IRequestHandler<DeleteDirectorCommand>
{
    private readonly IRepositoryManager _repositoryManager;

    public DeleteDirectorCommandHandler(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }
    
    public async Task Handle(DeleteDirectorCommand request, CancellationToken cancellationToken)
    {
        var director = await _repositoryManager.DirectorRepository.GetDirectorAsync(request.DirectorId, cancellationToken: cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Director), request.DirectorId);
        
        await _repositoryManager.DirectorRepository.DeleteDirectorAsync(director, cancellationToken: cancellationToken);
        await _repositoryManager.SaveChangesAsync(cancellationToken: cancellationToken);
    }
}