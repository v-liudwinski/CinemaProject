using Cinema.Domain.Models.DTOs;
using Cinema.Domain.Models.ViewModels;

namespace Cinema.Service.Interfaces;

public interface ISeatService
{
    Task<IEnumerable<SeatViewModel>> GetAllAsync();
    Task<IEnumerable<SeatViewModel>> GetAllAvailableSeats(int id);
    Task<SeatViewModel> GetAsync(int id);
    Task<SeatViewModel> AddAsync(AddSeatWithHallIdRequest addSeatRequest);
    Task UpdateAsync(int id, UpdateSeatWithHallIdRequest updateSeatRequest);
    Task DeleteAsync(int id);
}
