using Cinema.Domain.Models.DTOs;
using Cinema.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.UI.Controllers;

[Route("api/halls")]
[ApiController]
public class HallController : ControllerBase
{
    private readonly IServiceManager _service;

    public HallController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllHalls()
    {
        var halls = await _service.HallService.GetAllAsync();

        return Ok(halls);
    }

    [HttpGet("{id:int}", Name = "HallById")]
    public async Task<IActionResult> GetHallByIdAsync(int id)
    {
        var hall = await _service.HallService.GetAsync(id);

        return Ok(hall);
    }

    [HttpGet("[action]/{cinemaId:int}")]
    public async Task<IActionResult> GetHallsByCinemaIdAsync(int cinemaId)
    {
        var hall = await _service.HallService.GetAllHallByCinemaIdAsync(cinemaId);

        return Ok(hall);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddHallAsync([FromBody] AddHallWithCinemaIdRequest addHallRequest)
    {
        var createdHall = await _service.HallService.AddAsync(addHallRequest);

        return CreatedAtRoute("HallById", new { id = createdHall.Id }, createdHall);
    }

    [HttpPut("{id:int}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateHallAsync(int id, [FromBody] UpdateHallWithCinemaIdRequest updateHallRequest)
    {
        await _service.HallService.UpdateAsync(id, updateHallRequest);

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteHallAsync(int id)
    {
        await _service.HallService.DeleteAsync(id);

        return NoContent();
    }
}
