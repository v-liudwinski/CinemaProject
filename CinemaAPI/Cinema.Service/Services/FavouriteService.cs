using AutoMapper;
using Cinema.Domain.ExceptionModels;
using Cinema.Domain.Models.Consts;
using Cinema.Domain.Models.DTOs;
using Cinema.Domain.Models.Entities;
using Cinema.Domain.Models.ViewModels;
using Cinema.Persistence.Interfaces;
using Cinema.Service.Interfaces;

namespace Cinema.Service.Services;

public class FavouriteService : IFavouriteService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _loggerManager;
    private readonly IMapper _mapper;

    public FavouriteService(IRepositoryManager repository, ILoggerManager loggerManager, IMapper mapper)
    {
        _repository = repository;
        _loggerManager = loggerManager;
        _mapper = mapper;
    }

    public async Task<List<FavouriteViewModel>?> GetByUserIdAsync(int id)
    {
        var favourites = await _repository.Favourite.GetFavouritesByUserIdAsync(id);
        if (favourites is null)
        {
            _loggerManager.LogError(ConstError.ERROR_BY_ID);
            throw new NotFoundException(ConstError.GetErrorForException(nameof(User), id));
        }

        return _mapper.Map<List<FavouriteViewModel>>(favourites);
    }

    public async Task<List<FavouriteViewModel>?> GetByMovieIdAsync(int id)
    {
        var favourites = await _repository.Favourite.GetFavouritesByMovieIdAsync(id);
        if (favourites is null)
        {
            _loggerManager.LogError(ConstError.ERROR_BY_ID);
            throw new NotFoundException(ConstError.GetErrorForException(nameof(Movie), id));
        }

        return _mapper.Map<List<FavouriteViewModel>>(favourites);
    }

    public async Task<FavouriteViewModel> GetAsync(int userDetailsId, int movieId)
    {
        var favourite = await FavouriteExists(userDetailsId, movieId);

        return _mapper.Map<FavouriteViewModel>(favourite);
    }

    public async Task<FavouriteViewModel> AddFavourite(AddFavouriteRequest addFavouriteRequest)
    {
        await MovieExists(addFavouriteRequest.MovieId);

        await UserDetailsExists(addFavouriteRequest.UserDetailsId);

        var existingFavourite = await _repository.Favourite
            .GetFavouriteAsync(addFavouriteRequest.UserDetailsId, addFavouriteRequest.MovieId);

        if (existingFavourite is not null)
        {
            _loggerManager.LogError(ConstError.ERROR_BY_ID);
            throw new NotFoundException(ConstError.GetErrorForExistingElement(nameof(Favourite)));
        }

        var favourite = _mapper.Map<Favourite>(addFavouriteRequest);

        _repository.Favourite.CreateFavourite(favourite);
        await _repository.SaveAsync();

        favourite = await _repository.Favourite.GetFavouriteAsync(favourite.UserDetailsId, favourite.MovieId);
        var favouriteToReturn = _mapper.Map<FavouriteViewModel>(favourite);

        return favouriteToReturn;
    }

    public async Task DeleteFavourite(int userDetailsId, int movieId)
    {
        await MovieExists(movieId);

        await UserDetailsExists(userDetailsId);

        var favourite = await FavouriteExists(userDetailsId, movieId);

        _repository.Favourite.DeleteFavourite(favourite);
        await _repository.SaveAsync();
    }

    private async Task<Favourite> FavouriteExists(int userDetailsId, int movieId)
    {
        var favourite = await _repository.Favourite.GetFavouriteAsync(userDetailsId, movieId);
        if (favourite is null)
        {
            _loggerManager.LogError(ConstError.ERROR_BY_ID);
            throw new NotFoundException(ConstError.GetErrorForException(nameof(Favourite), userDetailsId));
        }

        return favourite;
    }

    private async Task<Movie> MovieExists(int movieId)
    {
        var movie = await _repository.Movie.GetMovieAsync(movieId);
        if (movie is null)
        {
            _loggerManager.LogError(ConstError.ERROR_BY_ID);
            throw new NotFoundException(ConstError.GetErrorForException(nameof(Movie), movieId));
        }

        return movie;
    }
    private async Task<UserDetails> UserDetailsExists(int userDetailsId)
    {
        var userDetails = await _repository.UserDetails.GetUserDetailsAsync(userDetailsId);
        if (userDetails is null)
        {
            _loggerManager.LogError(ConstError.ERROR_BY_ID);
            throw new NotFoundException(ConstError.GetErrorForException(nameof(UserDetails), userDetailsId));
        }

        return userDetails;
    }
}