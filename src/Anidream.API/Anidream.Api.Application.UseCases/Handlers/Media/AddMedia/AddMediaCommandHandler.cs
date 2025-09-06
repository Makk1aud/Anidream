using Anidream.Api.Application.UseCases.Services.Interfaces;
using Anidream.Api.Application.Utils.Dtos;
using Anidream.Api.Application.Utils.Exceptions;
using AutoMapper;
using MediatR;

namespace Anidream.Api.Application.UseCases.Handlers.Media.AddMedia;

public class AddMediaCommandHandler : IRequestHandler<AddMediaCommand, MediaDto>
{
    private readonly IMediaService _mediaService;
    private readonly IMapper _mapper;

    public AddMediaCommandHandler(IMediaService mediaService, IMapper mapper)
    {
        _mediaService = mediaService;
        _mapper = mapper;
    }
    
    public async Task<MediaDto> Handle(AddMediaCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var media = _mapper.Map<Domain.Entities.Media>(request.MediaForCreationDto);
            var resultMedia = await _mediaService.AddMediaAsync(media, cancellationToken);
            await _mediaService.SaveChangesAsync(cancellationToken);
            
            return _mapper.Map<MediaDto>(resultMedia);
        }
        catch (Exception e)
        {
            throw new MediaBadRequestException("Ошибка добавления media", e);
        }
    }
}