using Cinema.Domain.Models.Entities;

namespace Cinema.Persistence.Interfaces;

public interface IPriceRepository
{
    Task<List<Price>> GetAllPricesAsync();
    Task<Price?> GetPriceAsync(int id, bool trackChanges = false);
    void CreatePrice(Price cinema);
    void DeletePrice(Price cinema);
}
