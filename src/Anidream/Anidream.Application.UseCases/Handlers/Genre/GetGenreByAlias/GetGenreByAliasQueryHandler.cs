using Anidream.Application.Contracts.Genre;
using Anidream.Application.Exceptions;
using Anidream.Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Anidream.Application.UseCases.Handlers.Genre.GetGenreByAlias;

internal sealed class GetGenreByAliasQueryHandler : IRequestHandler<GetGenreByAliasQuery, GenreResponse>
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;

    public GetGenreByAliasQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }
    
    public async Task<GenreResponse> Handle(GetGenreByAliasQuery request, CancellationToken cancellationToken)
    {
        var genre = await _repositoryManager.GenreRepository.GetGenreByAliasAsync(request.Alias, cancellationToken: cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Genre), request.Alias);
        return _mapper.Map<GenreResponse>(genre);
    }
}