using Cinema.Domain.Models.DTOs;
using Cinema.Domain.Models.ViewModels;

namespace Cinema.Service.Interfaces;

public interface IMovieGenreService
{
    Task AddAsync(AddMovieGenreRequest addMovieGenreRequest);
    Task DeleteAsync(int movieId, int genreId);
}
