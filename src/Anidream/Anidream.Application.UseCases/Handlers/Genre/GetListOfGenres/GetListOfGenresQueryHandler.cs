using Anidream.Application.Contracts.Genre;
using Anidream.Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Anidream.Application.UseCases.Handlers.Genre.GetListOfGenres;

internal sealed class GetListOfGenresQueryHandler : IRequestHandler<GetListOfGenresQuery, IReadOnlyCollection<GenreResponse>>
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;

    public GetListOfGenresQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }
    
    public async Task<IReadOnlyCollection<GenreResponse>> Handle(GetListOfGenresQuery request, CancellationToken cancellationToken)
    {
        var genres = await _repositoryManager.GenreRepository.GetGenresAsync(cancellationToken: cancellationToken);
        return _mapper.Map<IReadOnlyCollection<GenreResponse>>(genres);
    }
}