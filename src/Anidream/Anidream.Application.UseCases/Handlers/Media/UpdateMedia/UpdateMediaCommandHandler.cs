using Anidream.Application.Contracts;
using Anidream.Application.Contracts.Media;
using Anidream.Application.Exceptions;
using Anidream.Application.Interfaces;
using Anidream.Application.Services;
using AutoMapper;
using MediatR;

namespace Anidream.Application.UseCases.Handlers.Media.UpdateMedia;

internal sealed class UpdateMediaCommandHandler : IRequestHandler<UpdateMediaCommand, MediaResponse>
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;

    public UpdateMediaCommandHandler(IRepositoryManager  repositoryManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }
    
    public async Task<MediaResponse> Handle(UpdateMediaCommand request, CancellationToken cancellationToken)
    {
        var media = await _repositoryManager.MediaRepository.GetMediaAsync(request.MediaId, true, cancellationToken: cancellationToken);
        if (media == null)
            throw new MediaNotFoundException(request.MediaId);

        if (request.Request.DirectorId.HasValue)
        {
            var director = await _repositoryManager.DirectorRepository.GetDirectorAsync((Guid)request.Request.DirectorId, cancellationToken: cancellationToken)
                ?? throw new EntityNotFoundException(nameof(Director), (Guid)request.Request.DirectorId);
            media.DirectorId = director.DirectorId;
        }

        if (request.Request.StudioId.HasValue)
        {
            var studio = await _repositoryManager.StudioRepository.GetStudioAsync((Guid)request.Request.StudioId, cancellationToken: cancellationToken)
                           ?? throw new EntityNotFoundException(nameof(Studio), (Guid)request.Request.StudioId);
            media.StudioId = studio.StudioId;
        }
            
        if(request.Request.GenresIds != null && request.Request.GenresIds.Any())
            await UpdateMediaGenres(media, request.Request.GenresIds, cancellationToken);
        
        _mapper.Map(request.Request, media);
        await _repositoryManager.SaveChangesAsync(cancellationToken);
        
        var updatedMedia = await _repositoryManager.MediaRepository.GetMediaAsync(media.MediaId, cancellationToken: cancellationToken);
        return _mapper.Map<MediaResponse>(updatedMedia);
    }
    
    private async Task UpdateMediaGenres(Domain.Entities.Media media, IReadOnlyCollection<Guid> genresIds,CancellationToken cancellationToken)
    {
        var existsGenreIds = (await RepositoryHelper.GetGenresByIdsAsync(_repositoryManager.GenreRepository, genresIds, cancellationToken))
            .Select(x => x.GenreId)
            .ToList();
            
        await _repositoryManager.MediaGenreRepository.UpdateMediaGenres(media.MediaId, existsGenreIds, cancellationToken);
        await _repositoryManager.SaveChangesAsync(cancellationToken);
    }
}