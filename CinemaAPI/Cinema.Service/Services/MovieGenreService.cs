using AutoMapper;
using Cinema.Domain.ExceptionModels;
using Cinema.Domain.Models.Consts;
using Cinema.Domain.Models.DTOs;
using Cinema.Domain.Models.Entities;
using Cinema.Persistence.Interfaces;
using Cinema.Service.Interfaces;

namespace Cinema.Service.Services;

public class MovieGenreService : IMovieGenreService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _loggerManager;
    private readonly IMapper _mapper;

    public MovieGenreService(IRepositoryManager repository, ILoggerManager loggerManager, IMapper mapper)
    {
        _repository = repository;
        _loggerManager = loggerManager;
        _mapper = mapper;
    }

    public async Task AddAsync(AddMovieGenreRequest addMovieGenreRequest)
    {
        await MovieGenreExists(addMovieGenreRequest.MovieId, addMovieGenreRequest.GenreId);

        var movieGenre = _mapper.Map<MovieGenre>(addMovieGenreRequest);

        _repository.MovieGenre.CreateMovieGenre(movieGenre);
        await _repository.SaveAsync();
    }

    public async Task DeleteAsync(int movieId, int genreId)
    {
        var movieGenre = await _repository.MovieGenre.GetMovieGenreAsync(movieId, genreId);
        if (movieGenre is null)
        {
            _loggerManager.LogError(ConstError.ERROR_BY_ID);
            throw new NotFoundException(ConstError.GetMovieGenreDoesntHave(movieId, genreId));
        }

        _repository.MovieGenre.DeleteMovieGenre(movieGenre);
        await _repository.SaveAsync();
    }

    private async Task<MovieGenre?> MovieGenreExists(int movieId, int genreId, bool trackChanges = false)
    {
        var movie = await _repository.Movie.GetMovieAsync(movieId);
        if (movie is null)
        {
            _loggerManager.LogError(ConstError.ERROR_BY_ID);
            throw new NotFoundException(ConstError.GetErrorForException(nameof(Movie), movieId));
        }

        var genre = await _repository.Genre.GetGenreAsync(genreId);
        if (genre is null)
        {
            _loggerManager.LogError(ConstError.ERROR_BY_ID);
            throw new NotFoundException(ConstError.GetErrorForException(nameof(Genre), genreId));
        }

        var movieGenre = await _repository.MovieGenre.GetMovieGenreAsync(movieId, genreId);
        if (movieGenre is not null)
        {
            _loggerManager.LogError(ConstError.ERROR_BY_ID);
            throw new BadRequestException(ConstError.GetMovieGenreHas(movieId, genreId));
        }

        return movieGenre;
    }
}
