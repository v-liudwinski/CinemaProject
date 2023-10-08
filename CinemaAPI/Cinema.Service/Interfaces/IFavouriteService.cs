using Cinema.Domain.Models.DTOs;
using Cinema.Domain.Models.Entities;
using Cinema.Domain.Models.ViewModels;

namespace Cinema.Service.Interfaces;

public interface IFavouriteService
{
    Task<List<FavouriteViewModel>?> GetByUserIdAsync(int id);
    Task<List<FavouriteViewModel>?> GetByMovieIdAsync(int id);
    Task<FavouriteViewModel> GetAsync(int userDetailsId, int movieId);
    Task<FavouriteViewModel> AddFavourite(AddFavouriteRequest addFavouriteRequest);
    Task DeleteFavourite(int id, int movieId);
}