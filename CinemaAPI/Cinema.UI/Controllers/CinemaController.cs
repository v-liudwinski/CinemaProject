using Cinema.Domain.Models.DTOs;
using Cinema.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.UI.Controllers;

[Route("api/cinemas")]
[ApiController]
public class CinemaController : ControllerBase
{
    private readonly IServiceManager _service;

    public CinemaController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCinemas()
    {
        var cinemas = await _service.CinemaService.GetAllAsync();
        
        return Ok(cinemas);
    }

    [HttpGet("{id:int}", Name = "CinemaById")]
    public async Task<IActionResult> GetCinemaByIdAsync(int id)
    {
        var cinema = await _service.CinemaService.GetAsync(id);

        return Ok(cinema);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddCinemaAsync([FromBody] AddCinemaRequest addCinemaRequest)
    {
        var createdCinema = await _service.CinemaService.AddAsync(addCinemaRequest);

        return CreatedAtRoute("CinemaById", new { id = createdCinema.Id }, createdCinema);
    }

    [HttpPut("{id:int}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateCinemaAsync(int id, [FromBody] UpdateCinemaRequest updateCinemaRequest)
    {
        await _service.CinemaService.UpdateAsync(id, updateCinemaRequest);

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteCinemaAsync(int id)
    {
        await _service.CinemaService.DeleteAsync(id);

        return NoContent();
    }
}