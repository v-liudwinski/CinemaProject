using Cinema.Domain.Models.Entities;
using Cinema.Persistence.Data;
using Cinema.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Persistence.Repositories;

public class FavouriteRepository : RepositoryBase<Favourite>, IFavouriteRepository
{
    public FavouriteRepository(RepositoryContext repositoryContext) 
        : base(repositoryContext)
    { }

    public async Task<List<Favourite>?> GetFavouritesByUserIdAsync(int id)
    {
        return await FindByCondition(x => x.UserDetails.UserId == id, false)
            .ToListAsync();
    }

    public async Task<List<Favourite>?> GetFavouritesByMovieIdAsync(int id)
    {
        return await FindByCondition(x => x.MovieId == id, false)
            .ToListAsync();
    }

    public async Task<Favourite?> GetFavouriteAsync(int userDetailsId, int movieId)
    {
        return await FindByCondition(x => 
                x.MovieId == movieId && x.UserDetailsId == userDetailsId, false)
            .FirstOrDefaultAsync();
    }

    public void CreateFavourite(Favourite favourite)
    {
        Create(favourite);
    }

    public void DeleteFavourite(Favourite favourite)
    {
        Delete(favourite);
    }
}