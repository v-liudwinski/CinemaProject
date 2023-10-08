using Cinema.Domain.Models.Entities;
using Cinema.Domain.RequestFeatures;

namespace Cinema.Persistence.Interfaces;

public interface IPurchaseRepository
{
    Task<PagedList<Purchase>> GetAllPurchasesAsync(PurchaseParameters purchaseParameters);
    Task<Purchase?> GetPurchaseAsync(int id, bool trackChanges = false);
    Task<List<Purchase>> GetAllPurchaseByUserDetailsIdAsync(int id);
    void CreatePurchase(Purchase purchase);
    void DeletePurchase(Purchase purchase);
}
