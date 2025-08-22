using Anidream.Api.Application.Core;
using Anidream.Api.Application.UseCases.Services;
using Anidream.Api.Application.Utils.Dtos;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Anidream.Api.Application.UseCases.Handlers.Media.GetListOfMedia;

public class GetListOfMediaCommandHandler : IRequestHandler<GetListOfMediaCommand, PaginationList<MediaDto>>
{
    private readonly IDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetListOfMediaCommandHandler(IDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<PaginationList<MediaDto>> Handle(GetListOfMediaCommand request, CancellationToken cancellationToken)
    {
        var medias = await _dbContext.Medias
            .Include(x => x.Studio)
            .Include(x => x.Director)
            .ToListAsync(cancellationToken);
        
        var mediasDto = _mapper.Map<IReadOnlyCollection<MediaDto>>(medias); 
        
        return new PaginationList<MediaDto>(mediasDto, request.PaginationOptions.PageNumber, request.PaginationOptions.PageSize);
    }
}