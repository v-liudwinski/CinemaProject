using Cinema.Domain.Models.DTOs;
using Cinema.Domain.Models.ViewModels;

namespace Cinema.Service.Interfaces;

public interface IHallService
{
    Task<IEnumerable<HallInfoViewModel>> GetAllAsync();
    Task<IEnumerable<HallInfoViewModel>> GetAllHallByCinemaIdAsync(int cinemaId);
    Task<HallInfoViewModel> GetAsync(int id);
    Task<HallInfoViewModel> AddAsync(AddHallWithCinemaIdRequest addHallRequest);
    Task UpdateAsync(int id, UpdateHallWithCinemaIdRequest updateHallRequest);
    Task DeleteAsync(int id);
}
