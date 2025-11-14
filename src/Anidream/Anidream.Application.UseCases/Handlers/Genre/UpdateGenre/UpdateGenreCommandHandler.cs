using Anidream.Application.Contracts.Genre;
using Anidream.Application.Exceptions;
using Anidream.Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Anidream.Application.UseCases.Handlers.Genre.UpdateGenre;

internal sealed class UpdateGenreCommandHandler : IRequestHandler<UpdateGenreCommand, GenreResponse>
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;

    public UpdateGenreCommandHandler(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }
    
    public async Task<GenreResponse> Handle(UpdateGenreCommand request, CancellationToken cancellationToken)
    {
        var genre = await _repositoryManager.GenreRepository.GetGenreAsync(request.GenreId, tracking: true, cancellationToken: cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Genre), request.GenreId);   
        
        _mapper.Map(request.Request, genre);
        await _repositoryManager.GenreRepository.UpdateGenreAsync(genre, cancellationToken);
        await _repositoryManager.SaveChangesAsync(cancellationToken);
        return _mapper.Map<GenreResponse>(genre);
    }
}