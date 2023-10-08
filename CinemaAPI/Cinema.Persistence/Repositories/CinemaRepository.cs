using Cinema.Persistence.Data;
using Cinema.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Persistence.Repositories;

public class CinemaRepository : RepositoryBase<Domain.Models.Entities.Cinema>, ICinemaRepository
{
    public CinemaRepository(RepositoryContext repositoryContext) 
        : base(repositoryContext)
    { }

    public void CreateCinema(Domain.Models.Entities.Cinema cinema)
    {
        Create(cinema);
    }

    public async Task<List<Domain.Models.Entities.Cinema>> GetAllCinemaAsync()
    {
        return await FindAll()
            .ToListAsync();
    }

    public async Task<Domain.Models.Entities.Cinema?> GetCinemaAsync(int id, bool trackChanges = false)
    {
        return await FindByCondition(x => x.Id == id, trackChanges)
            .FirstOrDefaultAsync();
    }

    public void DeleteCinema(Domain.Models.Entities.Cinema cinema)
    {
        Delete(cinema);
    }

    public async Task<Domain.Models.Entities.Cinema?> GetCinemaInfoAsync(int id)
    {
        return await FindByCondition(x => x.Id == id, false)
            .Include(x => x.Halls)
                .ThenInclude(x => x.Seats)
                    .ThenInclude(x => x.SeatType)
            .FirstOrDefaultAsync();
    }
}