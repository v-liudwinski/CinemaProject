using Cinema.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.UI.Controllers;

[Route("api/files")]
[ApiController]
public class FileController : ControllerBase
{
    private readonly IServiceManager _service;

    public FileController(IServiceManager service)
    {
        _service = service;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetImageAsync(int userId)
    {
        var imagePath = await _service.FileHandler.GetImageAsync(userId);
        var imageBytes = await System.IO.File.ReadAllBytesAsync(imagePath);
        return File(imageBytes, "image/jpeg");
    }

    [HttpPost]
    public async Task<IActionResult> UploadImageAsync(int userId, IFormFile image)
    {
        await _service.FileHandler.UploadImageAsync(userId, image);
        return NoContent();
    }
}