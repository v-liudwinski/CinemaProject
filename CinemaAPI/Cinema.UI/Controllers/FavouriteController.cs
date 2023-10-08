using Cinema.Domain.Models.DTOs;
using Cinema.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.UI.Controllers;

[Route("api/favourites")]
[ApiController]

public class FavouriteController : ControllerBase
{
    private readonly IServiceManager _service;

    public FavouriteController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet("by-user-id")]
    public async Task<IActionResult> GetFavouritesByUserIdAsync(int id)
    {
        var favourites = await _service.FavouriteService.GetByUserIdAsync(id);

        return Ok(favourites);
    }
    
    [HttpGet("by-movie-id")]
    public async Task<IActionResult> GetFavouritesByMovieIdAsync(int id)
    {
        var favourites = await _service.FavouriteService.GetByMovieIdAsync(id);

        return Ok(favourites);
    }

    [HttpGet("{userDetailsId:int}&{movieId:int}")]
    [ActionName("GetFavouriteByIdAsync")]
    public async Task<IActionResult> GetFavouriteByIdAsync(int userDetailsId, int movieId)
    {
        var favourite = await _service.FavouriteService.GetAsync(userDetailsId, movieId);

        return Ok(favourite);
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddFavouriteAsync(AddFavouriteRequest addFavouriteRequest)
    {
        await _service.FavouriteService.AddFavourite(addFavouriteRequest);

        return NoContent();
    }

    [HttpDelete("{userDetailsId:int}&{movieId:int}")]
    public async Task<IActionResult> DeleteFavouriteAsync(int userDetailsId, int movieId)
    {
        await _service.FavouriteService.DeleteFavourite(userDetailsId, movieId);

        return NoContent();
    }
}