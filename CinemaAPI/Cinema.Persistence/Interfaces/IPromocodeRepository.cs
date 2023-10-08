using Cinema.Domain.Models.Entities;

namespace Cinema.Persistence.Interfaces;

public interface IPromocodeRepository
{
    Task<List<Promocode>> GetAllPromocodeAsync();
    Task<Promocode?> GetPromocodeAsync(int id, bool trackChanges = false);
    Task<Promocode?> GetPromocodeAsync(string promocode);
    void CreatePromocode(Promocode promocode);
    void DeletePromocode(Promocode promocode);
}
