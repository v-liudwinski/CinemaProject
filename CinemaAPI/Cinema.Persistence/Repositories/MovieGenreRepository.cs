using Cinema.Domain.Models.Entities;
using Cinema.Persistence.Data;
using Cinema.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Persistence.Repositories;

public class MovieGenreRepository : RepositoryBase<MovieGenre>, IMovieGenreRepository
{
    public MovieGenreRepository(RepositoryContext repositoryContext) 
        : base(repositoryContext)
    { }

    public void CreateMovieGenres(ICollection<MovieGenre> movieGenres)
    {
        _repositoryContext.AddRange(movieGenres);
    }

    public void CreateMovieGenre(MovieGenre movieGenre)
    {
        Create(movieGenre);
    }

    public void DeleteMovieGenre(MovieGenre movieGenre)
    {
        Delete(movieGenre);
    }

    public async Task<MovieGenre?> GetMovieGenreAsync(int movieId, int genreId)
    {
        return await FindByCondition(x => x.MovieId == movieId && x.GenreId == genreId, false)
            .FirstOrDefaultAsync();
    }
}
