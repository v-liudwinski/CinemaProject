using AutoMapper;
using Cinema.Domain.Models.ViewModels;
using Cinema.Persistence.Interfaces;
using Cinema.Service.Interfaces;

namespace Cinema.Service.Services;

public class TicketService : ITicketService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _loggerManager;
    private readonly IMapper _mapper;

    public TicketService(IRepositoryManager repository, ILoggerManager loggerManager, IMapper mapper)
    {
        _repository = repository;
        _loggerManager = loggerManager;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TicketViewModel>> GetAllAsync()
    {
        var tickets = await _repository.Ticket.GetAllTicketsAsync();

        return _mapper.Map<List<TicketViewModel>>(tickets);
    }

    public async Task<TicketViewModel> GetTicketAsync(int id)
    {
        var ticket = await _repository.Ticket.GetTicketAsync(id);

        return _mapper.Map<TicketViewModel>(ticket);
    }
}
