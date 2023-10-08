using Cinema.Domain.ExceptionModels;
using Cinema.Domain.Models.Consts;
using Cinema.Domain.Models.Entities;
using Cinema.Persistence.Interfaces;
using Cinema.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace Cinema.Service.Services;

public class FileHandler : IFileHandler
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _loggerManager;
    private readonly IWebHostEnvironment _environment;
    
    public FileHandler(IRepositoryManager repository, ILoggerManager loggerManager, IWebHostEnvironment environment)
    {
        _repository = repository;
        _loggerManager = loggerManager;
        _environment = environment;
    }

    public async Task UploadImageAsync(int userId, IFormFile image)
    {
        var user = await _repository.UserDetails.GetUserDetailsAsync(userId);
        if (user is null)
        {
            _loggerManager.LogError(ConstError.ERROR_BY_ID);
            throw new NotFoundException(ConstError.GetErrorForException(nameof(User), userId));
        }

        if (File.Exists(user.AvatarUrl))
        {
            File.Delete(user.AvatarUrl);
        }
        
        var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");
        if (!Directory.Exists(uploadsFolder))
            Directory.CreateDirectory(uploadsFolder);

        var filePath = Path.Combine(uploadsFolder, image.FileName);
        await using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await image.CopyToAsync(stream);
        }
        
        user.AvatarUrl = filePath;
        await _repository.SaveAsync();
    }

    public async Task<string> GetImageAsync(int userId)
    {
        var user = await _repository.UserDetails.GetUserDetailsAsync(userId);
        if (user is null)
        {
            _loggerManager.LogError(ConstError.ERROR_BY_ID);
            throw new NotFoundException(ConstError.GetErrorForException(nameof(User), userId));
        }

        var imagePath = user.AvatarUrl;

        if (!File.Exists(imagePath))
        {
            throw new FileNotFoundException("The file was not found.", imagePath);
        }

        return imagePath;
    }
}