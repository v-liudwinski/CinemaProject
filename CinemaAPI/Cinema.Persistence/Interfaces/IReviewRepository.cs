using Cinema.Domain.Models.Entities;

namespace Cinema.Persistence.Interfaces;

public interface IReviewRepository
{
    Task<List<Review>> GetAllReviewsAsync();
    Task<Review?> GetReviewAsync(int id, bool trackChanges = false);
    Task<List<Review>?> GetReviewsByUserIdAsync(int id, bool trackChanges = false);
    Task<List<Review>?> GetReviewsByMovieIdAsync(int id, bool trackChanges = false);
    void CreateReview(Review review);
    void DeleteReview(Review review);
}