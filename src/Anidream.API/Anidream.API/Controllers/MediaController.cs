using Anidream.Api.Application.Core;
using Anidream.Api.Application.UseCases.Handlers.Media.GetListOfMedia;
using Anidream.Api.Application.UseCases.Services.Entities;
using Anidream.Api.Application.Utils.Dtos;
using Anidream.Api.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Anidream.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MediaController : ControllerBase
{
    private readonly IDbContext _context;
    private readonly ISender _sender;

    public MediaController(IDbContext context, ISender sender)
    {
        _context = context;
        _sender = sender;
    }

    [HttpGet("ping")]
    public IActionResult Ping()
    {
        return Ok("Pong");
    }

    [HttpGet]
    public async Task<IActionResult> GetMedias(
        [FromQuery] PaginationOptions paginationOptions,
        [FromBody] MediaFilter? filter = null,
        CancellationToken cancellationToken = default)
    {
        var medias = await _sender.Send(
            new GetListOfMediaCommand { PaginationOptions = paginationOptions, Filter = filter}, cancellationToken);
        Response.Headers.Append("X-Pagination", JsonConvert.SerializeObject(medias.GetMetadata()));
        
        return Ok(medias);
    }

    [HttpGet("{mediaId}")]
    public async Task<IActionResult> GetMediaById([FromRoute] Guid mediaId)
    {
        var media = await _context.Medias.FirstOrDefaultAsync(x => x.MediaId == mediaId);
        if(media is null)
            return NotFound();
        
        return Ok(media);
    }

    [HttpPost]
    public async Task<IActionResult> PostMedia([FromBody] MediaForCreationDto mediaDto)
    {
        throw new NotImplementedException();
    }
}