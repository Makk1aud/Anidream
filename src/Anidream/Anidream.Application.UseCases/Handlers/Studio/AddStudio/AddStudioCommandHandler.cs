using Anidream.Application.Contracts.Studio;
using Anidream.Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Anidream.Application.UseCases.Handlers.Studio.AddStudio;

internal sealed class AddStudioCommandHandler : IRequestHandler<AddStudioCommand, StudioResponse>
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;

    public AddStudioCommandHandler(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }
    
    public async Task<StudioResponse> Handle(AddStudioCommand request, CancellationToken cancellationToken)
    {
        var studio = _mapper.Map<Domain.Entities.Studio>(request.Request);
        await _repositoryManager.StudioRepository.AddStudioAsync(studio, cancellationToken);
        await _repositoryManager.SaveChangesAsync(cancellationToken);
        return _mapper.Map<StudioResponse>(studio);
    }
}