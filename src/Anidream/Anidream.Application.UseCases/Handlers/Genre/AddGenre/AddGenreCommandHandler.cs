using Anidream.Application.Contracts.Genre;
using Anidream.Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Anidream.Application.UseCases.Handlers.Genre.AddGenre;

internal sealed class AddGenreCommandHandler : IRequestHandler<AddGenreCommand, GenreResponse>
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;

    public AddGenreCommandHandler(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }
    
    public async Task<GenreResponse> Handle(AddGenreCommand request, CancellationToken cancellationToken)
    {
        var genre = _mapper.Map<Domain.Entities.Genre>(request.Request);
        await _repositoryManager.GenreRepository.AddGenreAsync(genre, cancellationToken);
        await _repositoryManager.SaveChangesAsync(cancellationToken);
        return _mapper.Map<GenreResponse>(genre);
    }
}