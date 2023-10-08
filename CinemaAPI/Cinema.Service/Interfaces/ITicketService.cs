using Cinema.Domain.Models.ViewModels;

namespace Cinema.Service.Interfaces;

public interface ITicketService
{
    Task<IEnumerable<TicketViewModel>> GetAllAsync();
    Task<TicketViewModel> GetTicketAsync(int id);
}
