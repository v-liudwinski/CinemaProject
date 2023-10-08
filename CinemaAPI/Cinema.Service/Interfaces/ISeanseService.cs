using Cinema.Domain.Models.DTOs;
using Cinema.Domain.Models.ViewModels;
using Cinema.Domain.RequestFeatures;

namespace Cinema.Service.Interfaces;

public interface ISeanseService
{
    Task<(IEnumerable<SeanseViewModel> seanses, MetaData metaData)> GetAllAsync(SeanseParameters seanseParameters);
    Task<SeanseInfoViewModel> GetAsync(int id);
    Task<SeanseViewModel> AddAsync(AddSeanseRequest addSeanseRequest);
    Task UpdateAsync(int id, UpdateSeanseRequest updateSeanseRequest);
    Task DeleteAsync(int id);
}
