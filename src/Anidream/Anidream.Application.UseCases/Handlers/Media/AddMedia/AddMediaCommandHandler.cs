using Anidream.Application.Contracts.Media;
using Anidream.Application.Exceptions;
using Anidream.Application.Interfaces;
using Anidream.Application.Services;
using Anidream.Domain.Entities;
using AutoMapper;
using MediatR;

namespace Anidream.Application.UseCases.Handlers.Media.AddMedia;

internal sealed class AddMediaCommandHandler : IRequestHandler<AddMediaCommand, MediaResponse>
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;

    public AddMediaCommandHandler(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }
    
    //Todo: ошибки если по внешним ключам будут отсутствовать данные в таблицах
    public async Task<MediaResponse> Handle(AddMediaCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var media = _mapper.Map<Domain.Entities.Media>(request.Request);
        
            if(request.Request.DirectorId.HasValue)
                media.DirectorId = (await _repositoryManager.DirectorRepository.GetDirectorAsync((Guid)request.Request.DirectorId, cancellationToken: cancellationToken))!.DirectorId;
                
            if(request.Request.StudioId.HasValue)
                media.StudioId = (await _repositoryManager.StudioRepository.GetStudioAsync((Guid)request.Request.StudioId, cancellationToken: cancellationToken))!.StudioId;

            await _repositoryManager.MediaRepository.AddMediaAsync(media, cancellationToken);
            await _repositoryManager.SaveChangesAsync(cancellationToken);
            
            await UpdateMediaGenres(media, request.Request.GenresIds, cancellationToken);

            var updatedMedia = await _repositoryManager.MediaRepository.GetMediaAsync(media.MediaId, cancellationToken: cancellationToken);
            return _mapper.Map<MediaResponse>(updatedMedia);
        }
        catch (Exception e)
        {
            throw new MediaBadRequestException("Ошибка добавления media", e);
        }
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