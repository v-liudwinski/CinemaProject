using AutoMapper;
using Cinema.Domain.ExceptionModels;
using Cinema.Domain.Models.Consts;
using Cinema.Domain.Models.DTOs;
using Cinema.Domain.Models.Entities;
using Cinema.Domain.Models.ViewModels;
using Cinema.Persistence.Interfaces;
using Cinema.Service.Interfaces;

namespace Cinema.Service.Services;

public class SeatService : ISeatService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _loggerManager;
    private readonly IMapper _mapper;

    public SeatService(IRepositoryManager repository, ILoggerManager loggerManager, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
        _loggerManager = loggerManager;
    }

    public async Task<SeatViewModel> AddAsync(AddSeatWithHallIdRequest addSeatRequest)
    {
        var seat = _mapper.Map<Seat>(addSeatRequest); 

        await HallExists(addSeatRequest.HallId);
        await SeatByNumberAndRowExists(seat.SeatNumber, seat.Row, seat.HallId);

        _repository.Seat.CreateSeat(seat);
        await _repository.SaveAsync();

        seat = await _repository.Seat.GetSeatAsync(seat.Id);

        var seatToReturn = _mapper.Map<SeatViewModel>(seat);
        return seatToReturn;
    }

    public async Task DeleteAsync(int id)
    {
        var seat = await SeatExists(id);

        _repository.Seat.DeleteSeat(seat);
        await _repository.SaveAsync();
    }

    public async Task<IEnumerable<SeatViewModel>> GetAllAsync()
    {
        var seats = await _repository.Seat.GetAllSeatsAsync();

        return _mapper.Map<List<SeatViewModel>>(seats);
    }

    public async Task<SeatViewModel> GetAsync(int id)
    {
        var seat = await SeatExists(id);

        return _mapper.Map<SeatViewModel>(seat);
    }

    public async Task UpdateAsync(int id, UpdateSeatWithHallIdRequest updateSeatRequest)
    {
        var hall = await HallExists(updateSeatRequest.HallId);
        await SeatByNumberAndRowExists(updateSeatRequest.SeatNumber, updateSeatRequest.Row, updateSeatRequest.HallId);

        var seat = await SeatExists(id, true);

        _mapper.Map(updateSeatRequest, seat);
        await _repository.SaveAsync();
    }

    public async Task<IEnumerable<SeatViewModel>> GetAllAvailableSeats(int id)
    {
        var seanse = await SeanseExists(id);

        var tickets = await _repository.Ticket.GetAllTicketsBySeanseId(id);
        var bookedSeats = tickets.Select(x => x.Seat).ToList();

        var currentHall = await HallExists(seanse.HallId);
        var allSeatsByHall = currentHall.Seats.ToList();

        var availableSeats = allSeatsByHall.ExceptBy(bookedSeats.Select(x => x.Id), x => x.Id);

        return _mapper.Map<List<SeatViewModel>>(availableSeats);
    }

    private async Task<Seat> SeatExists(int id, bool trackChanges = false)
    {
        var seat = await _repository.Seat.GetSeatAsync(id, trackChanges);
        if (seat is null)
        {
            _loggerManager.LogError(ConstError.ERROR_BY_ID);
            throw new NotFoundException(ConstError.GetErrorForException(nameof(Seat), id));
        }

        return seat;
    }

    private async Task<Seat?> SeatByNumberAndRowExists(int seatNum, int seatRow, int hallId)
    {
        var seat = await _repository.Seat.GetSeatByNumberAndRowAsync(seatNum, seatRow, hallId);
        if (seat is not null)
        {
            _loggerManager.LogError(ConstError.EXISTING_ENTITY);
            throw new BadRequestException(ConstError.GetErrorForExistingElement(nameof(Seat)));
        }

        return seat;
    }

    private async Task<Hall> HallExists(int id)
    {
        var hall = await _repository.Hall.GetHallInfoAsync(id);
        if (hall is null)
        {
            _loggerManager.LogError(ConstError.ERROR_BY_ID);
            throw new BadRequestException(ConstError.GetErrorForException(nameof(Hall), id));
        }

        return hall;
    }

    private async Task<Seanse> SeanseExists(int id)
    {
        var seanse = await _repository.Seanse.GetSeanseAsync(id);
        if (seanse is null)
        {
            _loggerManager.LogError(ConstError.ERROR_BY_ID);
            throw new NotFoundException(ConstError.GetErrorForException(nameof(Seanse), id));
        }

        return seanse;
    }
}
