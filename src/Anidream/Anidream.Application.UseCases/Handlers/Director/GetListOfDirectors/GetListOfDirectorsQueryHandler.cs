using Anidream.Application.Contracts.Director;
using Anidream.Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Anidream.Application.UseCases.Handlers.Director.GetDirectors;

internal sealed class GetListOfDirectorsQueryHandler : IRequestHandler<GetListOfDirectorsQuery, IReadOnlyCollection<DirectorResponse>>
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;

    public GetListOfDirectorsQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }
    
    public async Task<IReadOnlyCollection<DirectorResponse>> Handle(GetListOfDirectorsQuery request, CancellationToken cancellationToken)
    {
        var directors = await _repositoryManager.DirectorRepository.GetDirectorsAsync(cancellationToken: cancellationToken);
        return _mapper.Map<IReadOnlyCollection<DirectorResponse>>(directors);
    }
}