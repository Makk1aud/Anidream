using Anidream.Api.Application.Core;
using Anidream.Api.Application.Utils.Dtos;
using Anidream.Api.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Anidream.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MediaController : ControllerBase
{
    private readonly IDbContext _context;

    public MediaController(IDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetMedias()
    {
        return Ok(await _context.Medias.ToListAsync());
    }

    [HttpGet("{mediaId}")]
    public async Task<IActionResult> GetMedia([FromRoute] Guid mediaId)
    {
        var media = await _context.Medias.FirstOrDefaultAsync(x => x.MediaId == mediaId);
        if(media is null)
            return NotFound();
        
        return Ok(media);
    }

    [HttpPost]
    public async Task<IActionResult> PostMedia([FromBody] MediaForCreationDto mediaDto)
    {
        try
        {
            var media = new Media
            {
                Title = mediaDto.Title,
                Description = mediaDto.Description,
                Rating = mediaDto.Rating,
                Alias = mediaDto.Alias,
                StudioId = mediaDto.StudioId,
                DirectorId = mediaDto.DirectorId,
                ReleaseDate = mediaDto.ReleaseDate,
                TotalEpisodes = mediaDto.TotalEpisodes,
                CurrentEpisodes = mediaDto.CurrentEpisodes,
            };
            
            await _context.Medias.AddAsync(media);
            await _context.SaveChangesAsync();
            return Ok(media);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}