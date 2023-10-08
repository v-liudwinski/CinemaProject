using Cinema.Domain.Models.Entities;

namespace Cinema.Persistence.Interfaces;

public interface IFavouriteRepository
{
    Task<List<Favourite>?> GetFavouritesByUserIdAsync(int id);
    Task<List<Favourite>?> GetFavouritesByMovieIdAsync(int id);
    Task<Favourite?> GetFavouriteAsync(int userDetailsId, int movieId);
    void CreateFavourite(Favourite favourite);
    void DeleteFavourite(Favourite favourite);
}