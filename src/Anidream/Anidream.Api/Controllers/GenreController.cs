using Anidream.Application.Contracts.Genre;
using Anidream.Application.UseCases.Handlers.Genre.AddGenre;
using Anidream.Application.UseCases.Handlers.Genre.DeleteGenre;
using Anidream.Application.UseCases.Handlers.Genre.GetGenreByAlias;
using Anidream.Application.UseCases.Handlers.Genre.GetGenreById;
using Anidream.Application.UseCases.Handlers.Genre.GetListOfGenres;
using Anidream.Application.UseCases.Handlers.Genre.UpdateGenre;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Anidream.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GenreController : ControllerBase
{
    private readonly ISender _sender;

    public GenreController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> GetGenres(CancellationToken cancellationToken)
    {
        return Ok(await _sender.Send(new GetListOfGenresQuery(), cancellationToken));
    }
    
    [HttpGet("{genreId}")]
    public async Task<IActionResult> GetGenreById([FromRoute] Guid genreId, CancellationToken cancellationToken)
    {
        return Ok(await _sender.Send(new GetGenreByIdQuery(genreId), cancellationToken));
    }
    
    [HttpGet("alias/{alias}")]
    public async Task<IActionResult> GetGenreByAlias([FromRoute] string alias, CancellationToken cancellationToken)
    {
        return Ok(await _sender.Send(new GetGenreByAliasQuery(alias), cancellationToken));
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateGenre([FromBody] GenreRequest genreRequest, CancellationToken cancellationToken)
    {
        return Ok(await _sender.Send(new AddGenreCommand(genreRequest), cancellationToken));
    }
    
    [HttpPut("{genreId}")]
    public async Task<IActionResult> UpdateGenre([FromRoute] Guid genreId, [FromBody] GenreRequest genreRequest, CancellationToken cancellationToken)
    {
        return Ok(await _sender.Send(new UpdateGenreCommand(genreId, genreRequest), cancellationToken));
    }
    
    [HttpDelete("{genreId}")]
    public async Task<IActionResult> DeleteGenre([FromRoute] Guid genreId, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeleteGenreCommand(genreId), cancellationToken);
        return NoContent();
    }
}