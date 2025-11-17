using Anidream.Application.Exceptions;
using Anidream.Application.Interfaces;
using MediatR;

namespace Anidream.Application.UseCases.Handlers.Media.SetDeleteMediaStatus;

internal sealed class SetDeleteMediaStatusCommandHandler : IRequestHandler<SetDeleteMediaStatusCommand>
{
    private readonly IRepositoryManager _repositoryManager;

    public SetDeleteMediaStatusCommandHandler(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }
    
    //Todo: Пересмотреть удаление, и получение удаленных записей, потому что по факту в БД они занимают alias, даже если удалены
    public async Task Handle(SetDeleteMediaStatusCommand request, CancellationToken cancellationToken)
    {
        var media = await _repositoryManager.MediaRepository.GetMediaAsync(request.MediaId, true, false, cancellationToken);
        if(media == null)
            throw new MediaNotFoundException(request.MediaId);
        
        await _repositoryManager.MediaRepository.SetDeleteStatusMediaAsync(media, cancellationToken);
        await _repositoryManager.SaveChangesAsync(cancellationToken);
    }
}