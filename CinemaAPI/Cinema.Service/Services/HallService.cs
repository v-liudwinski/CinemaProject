using AutoMapper;
using Cinema.Domain.ExceptionModels;
using Cinema.Domain.Models.Consts;
using Cinema.Domain.Models.DTOs;
using Cinema.Domain.Models.Entities;
using Cinema.Domain.Models.ViewModels;
using Cinema.Persistence.Interfaces;
using Cinema.Service.Interfaces;

namespace Cinema.Service.Services;

public class HallService : IHallService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _loggerManager;
    private readonly IMapper _mapper;

    public HallService(IRepositoryManager repository, ILoggerManager loggerManager, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
        _loggerManager = loggerManager;
    }

    public async Task<HallInfoViewModel> AddAsync(AddHallWithCinemaIdRequest addHallRequest)
    {
        var cinema = await CinemaExists(addHallRequest.CinemaId);

        if (cinema.Halls.Any(x => x.HallNumber == addHallRequest.HallNumber))
        {
            _loggerManager.LogError(ConstError.ERROR_BY_ID);
            throw new NotFoundException(ConstError.GetErrorForExistingElement(nameof(Hall)));
        }

        var hall = _mapper.Map<Hall>(addHallRequest);

        _repository.Hall.CreateHall(hall);
        await _repository.SaveAsync();

        hall = await _repository.Hall.GetHallInfoAsync(hall.Id);
        var hallToReturn = _mapper.Map<HallInfoViewModel>(hall);
        return hallToReturn;
    }

    public async Task DeleteAsync(int id)
    {
        var hall = await HallExists(id);

        _repository.Hall.DeleteHall(hall);
        await _repository.SaveAsync();
    }

    public async Task<IEnumerable<HallInfoViewModel>> GetAllAsync()
    {
        var halls = await _repository.Hall.GetAllHallInfoAsync();

        return _mapper.Map<List<HallInfoViewModel>>(halls);
    }

    public async Task<IEnumerable<HallInfoViewModel>> GetAllHallByCinemaIdAsync(int cinemaId)
    {
        var halls = await _repository.Hall.GetAllHallByCinemaIdAsync(cinemaId);

        return _mapper.Map<List<HallInfoViewModel>>(halls);
    }

    public async Task<HallInfoViewModel> GetAsync(int id)
    {
        var hall = await _repository.Hall.GetHallInfoAsync(id);
        if (hall is null)
        {
            _loggerManager.LogError(ConstError.ERROR_BY_ID);
            throw new NotFoundException(ConstError.GetErrorForException(nameof(Hall), id));
        }

        return _mapper.Map<HallInfoViewModel>(hall);
    }

    public async Task UpdateAsync(int id, UpdateHallWithCinemaIdRequest updateHallRequest)
    {
        var existingCinema = await CinemaExists(updateHallRequest.CinemaId);
        var existingHall = await HallExists(id, true);

        if (existingCinema.Halls.Any(x => x.HallNumber == updateHallRequest.HallNumber))
        {
            _loggerManager.LogError(ConstError.ERROR_BY_ID);
            throw new BadRequestException(ConstError.GetErrorForExistingElement(nameof(Hall)));
        }

        _mapper.Map(updateHallRequest, existingHall);
        await _repository.SaveAsync();
    }

    private async Task<Hall> HallExists(int id, bool trackChanges = false)
    {
        var hall = await _repository.Hall.GetHallAsync(id, trackChanges);
        if (hall is null)
        {
            _loggerManager.LogError(ConstError.ERROR_BY_ID);
            throw new NotFoundException(ConstError.GetErrorForException(nameof(Hall), id));
        }

        return hall;
    }

    private async Task<Domain.Models.Entities.Cinema> CinemaExists(int id)
    {
        var cinema = await _repository.Cinema.GetCinemaInfoAsync(id);
        if (cinema is null)
        {
            _loggerManager.LogError(ConstError.ERROR_BY_ID);
            throw new NotFoundException(ConstError.GetErrorForException(nameof(Domain.Models.Entities.Cinema), id));
        }

        return cinema;
    }
}
