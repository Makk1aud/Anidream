using Anidream.Api.Application.Core;
using Anidream.Api.Application.Utils.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Anidream.Api.Application.UseCases.Handlers.Media.GetListOfMedia;

public class GetListOfMediaHandler : IRequestHandler<GetListOfMediaCommand, IReadOnlyCollection<MediaDto>>
{
    private readonly IDbContext _dbContext;

    public GetListOfMediaHandler(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyCollection<MediaDto>> Handle(GetListOfMediaCommand request, CancellationToken cancellationToken)
    {
        var medias = await _dbContext.Medias.ToListAsync(cancellationToken);
        
        
        return new List<MediaDto>();
    }
}