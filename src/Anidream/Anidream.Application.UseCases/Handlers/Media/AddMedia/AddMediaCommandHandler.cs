using Anidream.Application.Contracts;
using Anidream.Application.Contracts.Media;
using Anidream.Application.Exceptions;
using Anidream.Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Anidream.Application.UseCases.Handlers.Media.AddMedia;

internal sealed class AddMediaCommandHandler : IRequestHandler<AddMediaCommand, MediaResponse>
{
    private readonly IMediaRepository _mediaService;
    private readonly IMapper _mapper;

    public AddMediaCommandHandler(IMediaRepository mediaService, IMapper mapper)
    {
        _mediaService = mediaService;
        _mapper = mapper;
    }
    
    public async Task<MediaResponse> Handle(AddMediaCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var media = _mapper.Map<Domain.Entities.Media>(request.MediaForCreationRequest);
            var resultMedia = await _mediaService.AddMediaAsync(media, cancellationToken);
            await _mediaService.SaveChangesAsync(cancellationToken);
            
            return _mapper.Map<MediaResponse>(resultMedia);
        }
        catch (Exception e)
        {
            throw new MediaBadRequestException("Ошибка добавления media", e);
        }
    }

    //Todo: сделать обертку над DbSet чтобы можно было искать по ID и выкидывать exception на null
    private async Task Validate(MediaResponse mediaResponse)
    {
        
    }
}