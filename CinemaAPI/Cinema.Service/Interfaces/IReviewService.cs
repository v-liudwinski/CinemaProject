using Cinema.Domain.Models.DTOs;
using Cinema.Domain.Models.ViewModels;

namespace Cinema.Service.Interfaces;

public interface IReviewService
{
    Task<IEnumerable<ReviewViewModel>> GetAllAsync();
    Task<ReviewViewModel> GetAsync(int id);
    Task<IEnumerable<ReviewViewModel>?> GetByUserIdAsync(int id);
    Task<IEnumerable<ReviewViewModel>?> GetByMovieIdAsync(int id);
    Task<ReviewViewModel> AddAsync(AddReviewRequest addReviewRequest);
    Task UpdateAsync(int id, UpdateReviewRequest updateReviewRequest);
    Task DeleteAsync(int id);
}