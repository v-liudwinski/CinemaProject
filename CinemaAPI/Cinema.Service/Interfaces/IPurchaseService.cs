using Cinema.Domain.Models.DTOs;
using Cinema.Domain.Models.ViewModels;
using Cinema.Domain.RequestFeatures;

namespace Cinema.Service.Interfaces;

public interface IPurchaseService
{
    Task<(IEnumerable<PurchaseViewModelShort> purchases, MetaData metaData)> GetAllAsync(PurchaseParameters purchaseParameters);
    Task<PurchaseViewModel> GetAsync(int id);
    Task<List<PurchaseViewModel>> GetAllByUserDetailsIdAsync(int id);
    Task<PurchaseViewModel> AddAsync(AddPurchaseRequest addPurchaseRequest);
    Task DeleteAsync(int id);
}
