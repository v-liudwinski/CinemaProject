using Cinema.Domain.Models.Entities;
using Cinema.Domain.RequestFeatures;

namespace Cinema.Persistence.Interfaces;

public interface ISeanseRepository
{
    Task<PagedList<Seanse>> GetAllSeanseAsync(SeanseParameters seanseParameters);
    Task<Seanse?> GetSeanseAsync(int id, bool trackChanges = false);
    Task DeleteSeanseAsync(int id);
    void CreateSeanse(Seanse seanse);
    void DeleteSeanse(Seanse seanse);
}
