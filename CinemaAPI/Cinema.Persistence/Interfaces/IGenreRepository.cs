using Cinema.Domain.Models.Entities;

namespace Cinema.Persistence.Interfaces;

public interface IGenreRepository
{
    Task<Genre?> GetGenreAsync(int id); 
}
