using Cinema.Domain.Models.Entities;
using Cinema.Persistence.Data;
using Cinema.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Persistence.Repositories;

public class ReviewRepository : RepositoryBase<Review>, IReviewRepository
{
    public ReviewRepository(RepositoryContext repositoryContext) 
        : base(repositoryContext)
    { }

    public async Task<List<Review>> GetAllReviewsAsync()
    {
        return await FindAll()
            .ToListAsync();
    }

    public async Task<Review?> GetReviewAsync(int id, bool trackChanges = false)
    {
        return await FindByCondition(x => x.Id == id, trackChanges)
            .FirstOrDefaultAsync();
    }

    public async Task<List<Review>?> GetReviewsByUserIdAsync(int id, bool trackChanges = false)
    {
        return await FindByCondition(x => x.UserDetails.Id == id, trackChanges)
            .ToListAsync();
    }

    public async Task<List<Review>?> GetReviewsByMovieIdAsync(int id, bool trackChanges = false)
    {
        return await FindByCondition(x => x.MovieDetails.Id == id, trackChanges)
            .ToListAsync();
    }

    public void CreateReview(Review review)
    {
        Create(review);
    }

    public void DeleteReview(Review review)
    {
        Delete(review);
    }
}