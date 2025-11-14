using Anidream.Application.Contracts.Genre;
using Anidream.Application.Exceptions;
using Anidream.Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Anidream.Application.UseCases.Handlers.Genre.GetGenreById;

internal sealed class GetGenreByIdQueryHandler : IRequestHandler<GetGenreByIdQuery, GenreResponse>
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;

    public GetGenreByIdQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }
    
    public async Task<GenreResponse> Handle(GetGenreByIdQuery request, CancellationToken cancellationToken)
    {
        var genre = await _repositoryManager.GenreRepository.GetGenreAsync(request.GenreId, cancellationToken: cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Genre), request.GenreId);
        return _mapper.Map<GenreResponse>(genre);
    }
}