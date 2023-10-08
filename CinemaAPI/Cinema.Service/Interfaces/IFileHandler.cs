using Microsoft.AspNetCore.Http;

namespace Cinema.Service.Interfaces;

public interface IFileHandler
{
    Task UploadImageAsync(int userId, IFormFile image);
    Task<string> GetImageAsync(int userId);
}