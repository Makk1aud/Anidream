using Anidream.Application.Contracts.Director;
using Anidream.Application.Exceptions;
using Anidream.Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Anidream.Application.UseCases.Handlers.Director.UpdateDirector;

internal sealed class UpdateDirectorCommandHandler : IRequestHandler<UpdateDirectorCommand, DirectorResponse>
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;

    public UpdateDirectorCommandHandler(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }
    
    public async Task<DirectorResponse> Handle(UpdateDirectorCommand request, CancellationToken cancellationToken)
    {
        var director = await _repositoryManager.DirectorRepository.GetDirectorAsync(request.DirectorId, cancellationToken: cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Director), request.DirectorId);
        _mapper.Map(request.Request, director);
        await _repositoryManager.DirectorRepository.UpdateDirectorAsync(director, cancellationToken: cancellationToken);
        await _repositoryManager.SaveChangesAsync(cancellationToken: cancellationToken);
        return _mapper.Map<DirectorResponse>(director);
    }
}