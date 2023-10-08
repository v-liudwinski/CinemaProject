using Cinema.Domain.Models.DTOs;
using Cinema.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.UI.Controllers;

[Route("api/reviews")]
[ApiController]
public class ReviewController : ControllerBase
{
    private readonly IServiceManager _service;

    public ReviewController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllReviewsAsync()
    {
        var reviews = await _service.ReviewService.GetAllAsync();
        return Ok(reviews);
    }
    
    [HttpGet]
    [ActionName("GetReviewByIdAsync")]
    [Route("{id:int}")]
    public async Task<IActionResult> GetReviewByIdAsync(int id)
    {
        var reviews = await _service.ReviewService.GetAsync(id);
        return Ok(reviews);
    }
    
    [HttpGet]
    [Route("by-user-id")]
    public async Task<IActionResult> GetReviewsByUserIdAsync(int id)
    {
        var reviews = await _service.ReviewService.GetByUserIdAsync(id);
        return Ok(reviews);
    }
    
    [HttpGet]
    [Route("by-movie-id")]
    public async Task<IActionResult> GetReviewsByMovieIdAsync(int id)
    {
        var reviews = await _service.ReviewService.GetByMovieIdAsync(id);
        return Ok(reviews);
    }

    [HttpPost]
    [Authorize(Roles = "User, Admin")]
    public async Task<IActionResult> AddReviewAsync(AddReviewRequest addReviewRequest)
    {
        var createdReview = await _service.ReviewService.AddAsync(addReviewRequest);
        return CreatedAtAction(nameof(GetReviewByIdAsync), new { id = createdReview.Id }, createdReview);
    }

    [HttpPut("{id:int}")]
    [Authorize(Roles = "User, Admin")]
    public async Task<IActionResult> UpdateReviewAsync(int id, UpdateReviewRequest updateReviewRequest)
    {
        await _service.ReviewService.UpdateAsync(id, updateReviewRequest);
        return NoContent();
    }
    
    [HttpDelete("{id:int}")]
    [Authorize(Roles = "User, Admin")]
    public async Task<IActionResult> DeleteReviewAsync(int id)
    {
        await _service.ReviewService.DeleteAsync(id);
        return NoContent();
    }
}