using Anidream.Application.Contracts;
using Anidream.Application.Contracts.Media;
using Anidream.Application.Exceptions;
using Anidream.Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Anidream.Application.UseCases.Handlers.Media.UpdateMedia;

internal sealed class UpdateMediaCommandHandler : IRequestHandler<UpdateMediaCommand, MediaResponse>
{
    private readonly IMediaRepository _mediaService;
    private readonly IMapper _mapper;

    public UpdateMediaCommandHandler(IMediaRepository  mediaService, IMapper mapper)
    {
        _mediaService = mediaService;
        _mapper = mapper;
    }
    
    public async Task<MediaResponse> Handle(UpdateMediaCommand request, CancellationToken cancellationToken)
    {
        var media = await _mediaService.GetMediaAsync(request.MediaId, true, cancellationToken: cancellationToken);
        if (media == null)
            throw new MediaNotFoundException(request.MediaId);
        
        _mapper.Map(request.Request, media);
        await _mediaService.SaveChangesAsync(cancellationToken);
        
        return _mapper.Map<MediaResponse>(media);
    }
}