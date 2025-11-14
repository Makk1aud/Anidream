using Anidream.Application.Contracts.Studio;
using Anidream.Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Anidream.Application.UseCases.Handlers.Studio.GetListOfStudio;

internal sealed class GetListOfStudioQueryHandler : IRequestHandler<GetListOfStudiosQuery, IReadOnlyCollection<StudioResponse>>
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;

    public GetListOfStudioQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }
    
    public async Task<IReadOnlyCollection<StudioResponse>> Handle(GetListOfStudiosQuery request, CancellationToken cancellationToken)
    {
        var studios = 
            await _repositoryManager.StudioRepository.GetStudiosAsync(cancellationToken: cancellationToken);
        return _mapper.Map<IReadOnlyCollection<StudioResponse>>(studios);
    }
}