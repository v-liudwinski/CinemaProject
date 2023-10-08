using Cinema.Domain.Models.Entities;

namespace Cinema.Persistence.Interfaces;

public interface ITicketRepository
{
    Task<List<Ticket>> GetAllTicketsAsync();
    Task<List<Ticket>> GetAllTicketsBySeanseId(int id);
    Task<Ticket?> GetTicketAsync(int id);
}
