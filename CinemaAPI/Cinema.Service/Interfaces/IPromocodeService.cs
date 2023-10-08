using Cinema.Domain.Models.DTOs;
using Cinema.Domain.Models.ViewModels;

namespace Cinema.Service.Interfaces;

public interface IPromocodeService
{
    Task<IEnumerable<PromocodeViewModel>> GetAllAsync();
    Task<PromocodeViewModel> GetAsync(int id);
    Task<PromocodeViewModel> GetAsync(string promocode);
    Task<PromocodeViewModel> AddAsync(AddPromocodeRequest addPromocodeRequest);
    Task UpdateAsync(int id, UpdatePromocodeRequest updatePromocodeRequest);
    Task DeleteAsync(int id);
}
