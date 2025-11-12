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
    
    //Todo: Пересмотреть удаление, и получение удаленных записей, потому что по факту в БД они занимают alias, даже если удалены
    public async Task Handle(DeleteMediaCommand request, CancellationToken cancellationToken)
    {
        var media = await _repositoryManager.MediaRepository.GetMediaAsync(request.MediaId, true, false, cancellationToken);
        if(media == null)
            throw new MediaNotFoundException(request.MediaId);
        
        await _repositoryManager.MediaRepository.DeleteMediaAsync(media, cancellationToken);
        await _repositoryManager.SaveChangesAsync(cancellationToken);
    }
}