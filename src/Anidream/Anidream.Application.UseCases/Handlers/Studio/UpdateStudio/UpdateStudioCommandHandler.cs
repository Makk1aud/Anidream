using Anidream.Application.Contracts.Studio;
using Anidream.Application.Exceptions;
using Anidream.Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Anidream.Application.UseCases.Handlers.Studio.UpdateStudio;

internal sealed class UpdateStudioCommandHandler : IRequestHandler<UpdateStudioCommand, StudioResponse>
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;

    public UpdateStudioCommandHandler(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }
    
    public async Task<StudioResponse> Handle(UpdateStudioCommand request, CancellationToken cancellationToken)
    {
        var studio = await _repositoryManager.StudioRepository.GetStudioAsync(request.StudioId, cancellationToken: cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Studio), request.StudioId);
        _mapper.Map(request.Request, studio);
        await _repositoryManager.StudioRepository.UpdateStudioAsync(studio, cancellationToken);
        await _repositoryManager.SaveChangesAsync(cancellationToken);
        return _mapper.Map<StudioResponse>(studio);
    }
}