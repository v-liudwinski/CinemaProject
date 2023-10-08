using Cinema.Domain.Models.Entities;
using Cinema.Domain.RequestFeatures;
using Cinema.Persistence.Data;
using Cinema.Persistence.Extensions;
using Cinema.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Persistence.Repositories;

public class MovieRepository : RepositoryBase<Movie>, IMovieRepository
{
    public MovieRepository(RepositoryContext repositoryContext) 
        : base(repositoryContext)
    { }

    public async Task<PagedList<Movie>> GetAllMoviesAsync(MovieParameters movieParameters)
    {
        var movies = await FindAll()
            .OrderBy(x => x.Title)
            .Include(x => x.MovieDetails)
            .Include(x => x.MovieType)
            .Include(x => x.MovieGenres)
                .ThenInclude(x => x.Genre)
            .Search(movieParameters.SearchTerm)
            .Skip((movieParameters.PageNumber - 1) * movieParameters.PageSize)
            .Take(movieParameters.PageSize)
            .ToListAsync();

        var count = await FindAll().CountAsync();
        return new PagedList<Movie>(movies, count, movieParameters.PageNumber, movieParameters.PageSize);
    }

    public async Task<PagedList<Movie>> GetMoviesByUserFavouritesAsync(int userId, MovieParameters movieParameters)
    {
        var movies = FindAll()
            .SelectMany(x => x.Favourites
                .Where(f => f.UserDetails.UserId == userId))
            .Select(x => x.Movie);
        var filteredMovies = await movies
            .OrderBy(x => x.Title)
            .Search(movieParameters.SearchTerm)
            .Skip((movieParameters.PageNumber - 1) * movieParameters.PageSize)
            .Take(movieParameters.PageSize)
            .ToListAsync();
        
        var count = movies.Count();
        return new PagedList<Movie>(filteredMovies, count, movieParameters.PageNumber, movieParameters.PageSize);
    }

    public async Task<Movie?> GetMovieAsync(int id, bool trackChanges = false)
    {
        return await FindByCondition(x => x.Id == id, trackChanges)
            .FirstOrDefaultAsync();
    }

    public async Task<Movie?> GetMovieInfoAsync(int id, bool trackChanges = false)
    {
        return await FindByCondition(x => x.Id == id, trackChanges)
            .Include(x => x.MovieDetails)
            .Include(x => x.MovieType)
            .Include(x => x.MovieGenres)
                .ThenInclude(x => x.Genre)
            .SingleAsync();
    }

    public async Task<Movie?> GetMovieByTittleAsync(string tittle)
    {
        return await FindByCondition(x => x.Title == tittle, false)
            .FirstOrDefaultAsync();
    }

    public async Task<Movie?> CalculateUsersRate(int movieId)
    {
        var reviews = await FindByCondition(x => x.Id == movieId, false)
            .SelectMany(x => x.MovieDetails.Reviews)
            .ToListAsync();

        var movie = await FindByCondition(x => x.Id == movieId, true)
            .Include(x => x.MovieDetails)
            .SingleAsync();

        if (reviews.Any())
        {
            movie.MovieDetails.UsersRate = reviews.Select(x => x.Rate).Average();
        }
        return movie;
    }

    public void CreateMovie(Movie movie)
    {
        Create(movie);
    }

    public void DeleteMovie(Movie movie)
    {
        Delete(movie);
    }

    public async Task<Movie?> GetMovieByMovieDetailsIdAsync(int movieDetailsId)
    {
        return await FindByCondition(x => x.MovieDetails.Id == movieDetailsId, false)
            .Include(x => x.MovieDetails)
            .FirstOrDefaultAsync();
    }
}
