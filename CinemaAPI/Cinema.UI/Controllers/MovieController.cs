using Cinema.Domain.Models.DTOs;
using Cinema.Domain.RequestFeatures;
using Cinema.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;

namespace Cinema.UI.Controllers;

[Route("api/movies")]
[ApiController]
public class MovieController : ControllerBase
{
    private readonly IServiceManager _service;

    public MovieController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetAllMoviesAsync([FromQuery] MovieParameters movieParameters)
    {
        var pagedResult = await _service.MovieService.GetAllAsync(movieParameters);

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));

        return Ok(pagedResult.movies);        
    }
    
    [HttpGet("[action]/{userId:int}")]
    public async Task<IActionResult> GetMoviesByUserFavouritesAsync(int userId, [FromQuery] MovieParameters movieParameters)
    {
        var pagedResult = await _service.MovieService.GetByUserFavourites(userId, movieParameters);

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));

        return Ok(pagedResult.movies);        
    }

    [HttpGet("[action]/{id:int}")]
    public async Task<IActionResult> GetMovieInfoAsync(int id)
    {
        var movie = await _service.MovieService.GetInfoAsync(id);
       
        return Ok(movie);
    }

    [HttpGet("[action]/{id:int}")]
    [ActionName("GetMoviesByIdAsync")]
    public async Task<IActionResult> GetMoviesByIdAsync(int id)
    {
        var movie = await _service.MovieService.GetAsync(id);
        
        return Ok(movie);
    }

    [HttpPut("users-rate/{movieId:int}")]
    public async Task<IActionResult> CalculateUsersRateAsync(int movieId)
    {
        await _service.MovieService.CalculateUserRate(movieId);
        return NoContent();
    }

    [HttpGet("[action]/{movieDetailsId:int}")]
    public async Task<IActionResult> GetMovieByMovieDetailsIdAsync(int movieDetailsId)
    {
        var movie = await _service.MovieService.GetByMovieDetailsIdAsync(movieDetailsId);

        return Ok(movie);
    }

    [HttpPost("[action]")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddMovieAsync([FromBody] AddMovieRequest addMovieRequest)
    {
        var createdMovie = await _service.MovieService.AddAsync(addMovieRequest);

        return CreatedAtAction(nameof(GetMoviesByIdAsync), new { id = createdMovie.Id }, createdMovie);        
    }

    [HttpPut("[action]/{id:int}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateMovieAsync(int id, [FromBody] UpdateMovieRequest updateMovieRequest)
    {
        await _service.MovieService.UpdateAsync(id, updateMovieRequest);        

        return NoContent();
    }

    [HttpDelete("[action]/{id:int}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteMovieAsync(int id)
    {
        await _service.MovieService.DeleteAsync(id);
        
        return NoContent();
    }
}
