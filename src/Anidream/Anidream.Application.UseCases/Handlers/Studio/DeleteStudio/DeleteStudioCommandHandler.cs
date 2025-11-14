using Anidream.Application.Exceptions;
using Anidream.Application.Interfaces;
using MediatR;

namespace Anidream.Application.UseCases.Handlers.Studio.DeleteStudio;

internal sealed class DeleteStudioCommandHandler : IRequestHandler<DeleteStudioCommand>
{
    private readonly IRepositoryManager _repositoryManager;

    public DeleteStudioCommandHandler(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }
    
    public async Task Handle(DeleteStudioCommand request, CancellationToken cancellationToken)
    {
        var studio = await _repositoryManager.StudioRepository.GetStudioAsync(request.StudioId, cancellationToken: cancellationToken) 
            ?? throw new EntityNotFoundException(nameof(Studio), request.StudioId); 
        await _repositoryManager.StudioRepository.DeleteStudioAsync(studio, cancellationToken);
        await _repositoryManager.SaveChangesAsync(cancellationToken);
    }
}