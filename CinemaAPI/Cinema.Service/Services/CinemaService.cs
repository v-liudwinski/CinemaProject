using AutoMapper;
using Cinema.Domain.ExceptionModels;
using Cinema.Domain.Models.Consts;
using Cinema.Domain.Models.DTOs;
using Cinema.Domain.Models.ViewModels;
using Cinema.Persistence.Interfaces;
using Cinema.Service.Interfaces;

namespace Cinema.Service.Services;

public class CinemaService : ICinemaService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _loggerManager;
    private readonly IMapper _mapper;

    public CinemaService(IRepositoryManager repository, ILoggerManager loggerManager, IMapper mapper)
    {
        _repository = repository;        
        _loggerManager = loggerManager;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CinemaViewModel>> GetAllAsync()
    {
        var cinemas = await _repository.Cinema.GetAllCinemaAsync();

        return _mapper.Map<List<CinemaViewModel>>(cinemas);
    }

    public async Task<CinemaInfoViewModel> GetAsync(int id)
    {
        var cinema = await _repository.Cinema.GetCinemaInfoAsync(id);
        if (cinema is null)
        {
            _loggerManager.LogError(ConstError.ERROR_BY_ID);
            throw new NotFoundException(ConstError.GetErrorForException(nameof(Domain.Models.Entities.Cinema), id));
        }

        return _mapper.Map<CinemaInfoViewModel>(cinema);
    }

    public async Task<CinemaInfoViewModel> AddAsync(AddCinemaRequest addCinemaRequest)
    {
        var cinema = _mapper.Map<Domain.Models.Entities.Cinema>(addCinemaRequest);

        _repository.Cinema.CreateCinema(cinema);
        await _repository.SaveAsync();

        cinema = await _repository.Cinema.GetCinemaInfoAsync(cinema.Id);

        var cinemaToReturn = _mapper.Map<CinemaInfoViewModel>(cinema);
        return cinemaToReturn;
    }

    public async Task UpdateAsync(int id, UpdateCinemaRequest updateCinemaRequest)
    {
        var cinema = await CinemaExists(id, true);

        _mapper.Map(updateCinemaRequest, cinema);
        await _repository.SaveAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var cinema = await CinemaExists(id);

        _repository.Cinema.DeleteCinema(cinema);
        await _repository.SaveAsync();
    }

    private async Task<Domain.Models.Entities.Cinema> CinemaExists(int id, bool trackChanges = false)
    {
        var cinema = await _repository.Cinema.GetCinemaAsync(id, trackChanges);
        if (cinema is null)
        {
            _loggerManager.LogError(ConstError.ERROR_BY_ID);
            throw new NotFoundException(ConstError.GetErrorForException(nameof(Domain.Models.Entities.Cinema), id));
        }

        return cinema;
    }
}