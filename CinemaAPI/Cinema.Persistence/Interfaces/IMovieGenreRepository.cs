using Cinema.Domain.Models.Entities;

namespace Cinema.Persistence.Interfaces;

public interface IMovieGenreRepository
{
    void CreateMovieGenres(ICollection<MovieGenre> movieGenres);
    void CreateMovieGenre(MovieGenre movieGenre);
    void DeleteMovieGenre(MovieGenre movieGenre);
    Task<MovieGenre?> GetMovieGenreAsync(int movieId, int genreId);
}
