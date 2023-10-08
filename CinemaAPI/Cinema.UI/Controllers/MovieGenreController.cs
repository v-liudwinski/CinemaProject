using Cinema.Domain.Models.DTOs;
using Cinema.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.UI.Controllers;

[Route("api/movieGenre")]
[ApiController]

public class MovieGenreController : ControllerBase
{
    private readonly IServiceManager _service;

    public MovieGenreController(IServiceManager service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> AddMovieGenreAsync([FromBody] AddMovieGenreRequest addMovieGenreRequest)
    {
        await _service.MovieGenreService.AddAsync(addMovieGenreRequest);
        
        return Ok();
    }

    [HttpDelete("{movieId:int}&{genreId:int}")]
    public async Task<IActionResult> DeleteMovieGenreAsync(int movieId, int genreId)
    {
        await _service.MovieGenreService.DeleteAsync(movieId, genreId);

        return NoContent();
    }
}
