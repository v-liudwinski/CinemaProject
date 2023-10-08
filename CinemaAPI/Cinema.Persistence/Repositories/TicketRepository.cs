using Cinema.Domain.Models.Entities;
using Cinema.Persistence.Data;
using Cinema.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Persistence.Repositories;

public class TicketRepository : RepositoryBase<Ticket>, ITicketRepository
{
    public TicketRepository(RepositoryContext repositoryContext) 
        : base(repositoryContext)
    { }

    public async Task<List<Ticket>> GetAllTicketsAsync()
    {
        return await FindAll()
            .Include(x => x.Seanse)
            .Include(x => x.Seat)
            .ToListAsync();
    }

    public async Task<List<Ticket>> GetAllTicketsBySeanseId(int id)
    {
        return await FindAll()
            .Where(x => x.Seanse.Id == id)
            .Include(x => x.Seanse)
            .Include(x => x.Seat)
            .ToListAsync();
    }

    public async Task<Ticket?> GetTicketAsync(int id)
    {
        return await FindByCondition(x => x.Id == id, false)
            .Include(x => x.Seat)
                .ThenInclude(x => x.SeatType)
            .Include(x => x.Seanse)
                    .ThenInclude(x => x.Movie)
            .Include(x => x.Seanse)
                    .ThenInclude(x => x.Price)
            .FirstOrDefaultAsync();     
    }
}
