using Anidream.Application.Exceptions;
using Anidream.Application.Interfaces;
using MediatR;

namespace Anidream.Application.UseCases.Handlers.Media.DeleteMedia;

internal sealed class DeleteMediaCommandHandler : IRequestHandler<DeleteMediaCommand>
{
    private readonly IRepositoryManager _repositoryManager;

    public DeleteMediaCommandHandler(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public async Task Handle(DeleteMediaCommand request, CancellationToken cancellationToken)
    {
        var media = await _repositoryManager.MediaRepository.GetMediaAsync(request.MediaId,  cancellationToken:  cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Media), request.MediaId);

        await _repositoryManager.MediaRepository.DeleteMediaAsync(media, cancellationToken: cancellationToken);
        await _repositoryManager.SaveChangesAsync(cancellationToken);
    }
}