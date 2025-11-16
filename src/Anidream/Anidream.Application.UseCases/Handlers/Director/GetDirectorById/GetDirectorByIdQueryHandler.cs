using Anidream.Application.Contracts.Director;
using Anidream.Application.Exceptions;
using Anidream.Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Anidream.Application.UseCases.Handlers.Director.GetDirectorById;

internal sealed class GetDirectorByIdQueryHandler : IRequestHandler<GetDirectorByIdQuery, DirectorResponse>
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;

    public GetDirectorByIdQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }
    
    public async Task<DirectorResponse> Handle(GetDirectorByIdQuery request, CancellationToken cancellationToken)
    {
        var director = await _repositoryManager.DirectorRepository.GetDirectorAsync(request.DirectorId, cancellationToken: cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Director), request.DirectorId);
        return _mapper.Map<DirectorResponse>(director);
    }
}