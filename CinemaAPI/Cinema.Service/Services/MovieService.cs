using AutoMapper;
using Cinema.Domain.ExceptionModels;
using Cinema.Domain.Models.Consts;
using Cinema.Domain.Models.DTOs;
using Cinema.Domain.Models.Entities;
using Cinema.Domain.Models.ViewModels;
using Cinema.Domain.RequestFeatures;
using Cinema.Persistence.Interfaces;
using Cinema.Service.Interfaces;

namespace Cinema.Service.Services;

public class MovieService : IMovieService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _loggerManager;
    private readonly IMapper _mapper;

    public MovieService(IRepositoryManager repository, ILoggerManager loggerManager, IMapper mapper)
    {
        _repository = repository;
        _loggerManager = loggerManager;
        _mapper = mapper;
    }

    public async Task<(IEnumerable<MovieInfoViewModel> movies, MetaData metaData)> GetAllAsync(MovieParameters movieParameters)
    {
        var moviesWithMediaData = await _repository.Movie.GetAllMoviesAsync(movieParameters);

        var moviesToReturn = _mapper.Map<IEnumerable<MovieInfoViewModel>>(moviesWithMediaData);

        return (movies: moviesToReturn, metaData: moviesWithMediaData.MetaData);
    }

    public async Task<(IEnumerable<MovieViewModel> movies, MetaData metaData)> GetByUserFavourites(int userId, MovieParameters movieParameters)
    {
        var moviesWithMediaData = await _repository.Movie.GetMoviesByUserFavouritesAsync(userId, movieParameters);

        var moviesToReturn = _mapper.Map<IEnumerable<MovieViewModel>>(moviesWithMediaData);

        return (movies: moviesToReturn, metaData: moviesWithMediaData.MetaData);
    }

    public async Task<MovieInfoViewModel> GetInfoAsync(int id)
    {
        var movie = await _repository.Movie.GetMovieInfoAsync(id);
        if (movie is null)
        {
            _loggerManager.LogError(ConstError.ERROR_BY_ID);
            throw new NotFoundException(ConstError.GetErrorForException(nameof(Movie), id));
        }
        movie.MovieDetails.IndependentRate = Math.Round(movie.MovieDetails.IndependentRate, 2);

        return _mapper.Map<MovieInfoViewModel>(movie);
    }

    public async Task<MovieViewModel> GetAsync(int id)
    {
        var movie = await MovieExists(id, true);

        return _mapper.Map<MovieViewModel>(movie);
    }

    public async Task<MovieInfoViewModel> AddAsync(AddMovieRequest addMovieRequest)
    {
        var movie = _mapper.Map<Movie>(addMovieRequest);

        _repository.Movie.CreateMovie(movie);
        _repository.MovieGenre.CreateMovieGenres(movie.MovieGenres);
        await _repository.SaveAsync();

        movie = await _repository.Movie.GetMovieInfoAsync(movie.Id);

        var movieToReturn = _mapper.Map<MovieInfoViewModel>(movie);
        return movieToReturn;
    }

    public async Task CalculateUserRate(int movieId)
    {
        var movie = await _repository.Movie.CalculateUsersRate(movieId);
        if (movie is null)
        {
            _loggerManager.LogError(ConstError.ERROR_BY_ID);
            throw new NotFoundException(ConstError.GetErrorForException(nameof(Movie), movieId));
        }
        await _repository.SaveAsync();
    }

    public async Task UpdateAsync(int id, UpdateMovieRequest updateMovieRequest)
    {
        var movie = await _repository.Movie.GetMovieInfoAsync(id, true);
        if (movie is null)
        {
            _loggerManager.LogError(ConstError.ERROR_BY_ID);
            throw new NotFoundException(ConstError.GetErrorForException(nameof(Movie), id));
        }

        _mapper.Map(updateMovieRequest, movie);
        await _repository.SaveAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var movie = await MovieExists(id);

        _repository.Movie.DeleteMovie(movie);
        await _repository.SaveAsync();
    }

    private async Task<Movie> MovieExists(int id, bool trackChanges = false)
    {
        var movie = await _repository.Movie.GetMovieAsync(id, trackChanges);
        if (movie is null)
        {
            _loggerManager.LogError(ConstError.ERROR_BY_ID);
            throw new NotFoundException(ConstError.GetErrorForException(nameof(Movie), id));
        }

        return movie;
    }

    public async Task<MovieViewModel> GetByMovieDetailsIdAsync(int movieDetailsId)
    {
        var movie = await _repository.Movie.GetMovieByMovieDetailsIdAsync(movieDetailsId);

        return _mapper.Map<MovieViewModel>(movie);
    }
}
