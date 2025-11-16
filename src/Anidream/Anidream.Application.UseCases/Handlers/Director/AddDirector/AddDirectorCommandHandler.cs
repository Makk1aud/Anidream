using Anidream.Application.Contracts.Director;
using Anidream.Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Anidream.Application.UseCases.Handlers.Director.AddDirector;

internal sealed class AddDirectorCommandHandler :  IRequestHandler<AddDirectorCommand, DirectorResponse>
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;

    public AddDirectorCommandHandler(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }
    
    public async Task<DirectorResponse> Handle(AddDirectorCommand request, CancellationToken cancellationToken)
    {
        var director = _mapper.Map<Domain.Entities.Director>(request.Request);
        await _repositoryManager.DirectorRepository.AddDirectorAsync(director, cancellationToken: cancellationToken);
        await _repositoryManager.SaveChangesAsync(cancellationToken);
        return _mapper.Map<DirectorResponse>(director);
    }
}