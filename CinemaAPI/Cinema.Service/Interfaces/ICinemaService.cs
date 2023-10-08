using Cinema.Domain.Models.DTOs;
using Cinema.Domain.Models.ViewModels;

namespace Cinema.Service.Interfaces;

public interface ICinemaService
{
    Task<IEnumerable<CinemaViewModel>> GetAllAsync();
    Task<CinemaInfoViewModel> GetAsync(int id);
    Task<CinemaInfoViewModel> AddAsync(AddCinemaRequest addCinemaRequest);
    Task UpdateAsync(int id, UpdateCinemaRequest updateCinemaRequest);
    Task DeleteAsync(int id);
}