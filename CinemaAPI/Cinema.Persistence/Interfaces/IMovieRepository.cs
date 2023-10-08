using Cinema.Domain.Models.Entities;
using Cinema.Domain.RequestFeatures;

namespace Cinema.Persistence.Interfaces;

public interface IMovieRepository
{
    Task<PagedList<Movie>> GetAllMoviesAsync(MovieParameters movieParameters);
    Task<PagedList<Movie>> GetMoviesByUserFavouritesAsync(int id, MovieParameters movieParameters);
    Task<Movie?> GetMovieAsync(int id, bool trackChanges = false);
    Task<Movie?> GetMovieByMovieDetailsIdAsync(int movieDetailsId);
    Task<Movie?> GetMovieInfoAsync(int userId, bool trackChanges = false);    
    Task<Movie?> GetMovieByTittleAsync(string tittle);
    Task<Movie?> CalculateUsersRate(int movieId);
    void CreateMovie(Movie movie);
    void DeleteMovie(Movie movie);
}
