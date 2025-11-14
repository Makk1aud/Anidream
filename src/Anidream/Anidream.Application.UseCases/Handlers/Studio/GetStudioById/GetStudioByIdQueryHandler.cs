using Anidream.Application.Contracts.Studio;
using Anidream.Application.Exceptions;
using Anidream.Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Anidream.Application.UseCases.Handlers.Studio.GetStudioById;

internal sealed class GetStudioByIdQueryHandler : IRequestHandler<GetStudioByIdQuery, StudioResponse>
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;

    public GetStudioByIdQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }

    public async Task<StudioResponse> Handle(GetStudioByIdQuery request, CancellationToken cancellationToken)
    {
        var studio = await _repositoryManager.StudioRepository.GetStudioAsync(request.StudioId, cancellationToken: cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Studio), request.StudioId);
        return _mapper.Map<StudioResponse>(studio);
    }
}