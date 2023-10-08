using Cinema.Domain.Models.Entities;
using Cinema.Persistence.Data;
using Cinema.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Persistence.Repositories;

public class SeatRepository : RepositoryBase<Seat>, ISeatRepository
{
    public SeatRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    { }

    public void CreateSeat(Seat seat)
    {
        Create(seat);
    }

    public void DeleteSeat(Seat seat)
    {
        Delete(seat);
    }

    public async Task<List<Seat>> GetAllSeatsAsync()
    {
        return await FindAll()
            .OrderBy(x => x.Id)
            .Include(x => x.SeatType)
            .ToListAsync();
    }

    public async Task<Seat?> GetSeatAsync(int id, bool trackChanges = false)
    {
        return await FindByCondition(x => x.Id == id, trackChanges)
            .Include(x => x.SeatType)
            .FirstOrDefaultAsync();
    }

    public async Task<Seat?> GetSeatByNumberAndRowAsync(int num, int row, int hallId)
    {
        return await FindByCondition(x => x.Row == row && x.SeatNumber == num && x.HallId == hallId, false)
            .FirstOrDefaultAsync();
    }
}
