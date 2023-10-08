namespace Cinema.Persistence.Interfaces;

public interface ICinemaRepository
{
    Task<List<Domain.Models.Entities.Cinema>> GetAllCinemaAsync();
    Task<Domain.Models.Entities.Cinema?> GetCinemaInfoAsync(int id);  
    Task<Domain.Models.Entities.Cinema?> GetCinemaAsync(int id, bool trackChanges = false);
    void CreateCinema(Domain.Models.Entities.Cinema cinema);
    void DeleteCinema(Domain.Models.Entities.Cinema cinema);
}