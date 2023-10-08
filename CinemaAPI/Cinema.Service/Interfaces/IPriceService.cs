using Cinema.Domain.Models.DTOs;
using Cinema.Domain.Models.ViewModels;

namespace Cinema.Service.Interfaces;

public interface IPriceService
{
    Task<IEnumerable<PriceViewModel>> GetAllAsync();
    Task<PriceViewModel> GetAsync(int id);
    Task<PriceViewModel> AddAsync(AddPriceRequest addCinemaRequest);
    Task UpdateAsync(int id, UpdatePriceRequest updateCinemaRequest);
    Task DeleteAsync(int id);
}