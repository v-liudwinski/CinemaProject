using AutoMapper;
using Cinema.Domain.ExceptionModels;
using Cinema.Domain.Models.Consts;
using Cinema.Domain.Models.DTOs;
using Cinema.Domain.Models.Entities;
using Cinema.Domain.Models.ViewModels;
using Cinema.Persistence.Interfaces;
using Cinema.Service.Interfaces;

namespace Cinema.Service.Services;

public class PriceService : IPriceService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _loggerManager;
    private readonly IMapper _mapper;

    public PriceService(IRepositoryManager repository, ILoggerManager loggerManager, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
        _loggerManager = loggerManager;
    }

    public async Task<PriceViewModel> AddAsync(AddPriceRequest addPriceRequest)
    {
        var price = _mapper.Map<Price>(addPriceRequest);

        _repository.Price.CreatePrice(price);
        await _repository.SaveAsync();

        var priceToReturn = _mapper.Map<PriceViewModel>(price);
        return priceToReturn;
    }

    public async Task DeleteAsync(int id)
    {
        var price = await PriceExists(id);

        _repository.Price.DeletePrice(price);
        await _repository.SaveAsync();
    }

    public async Task<IEnumerable<PriceViewModel>> GetAllAsync()
    {
        var prices = await _repository.Price.GetAllPricesAsync();

        return _mapper.Map<List<PriceViewModel>>(prices);
    }

    public async Task<PriceViewModel> GetAsync(int id)
    {
        var price = await PriceExists(id);

        return _mapper.Map<PriceViewModel>(price);
    }

    public async Task UpdateAsync(int id, UpdatePriceRequest updateCinemaRequest)
    {
        var price = await PriceExists(id, true);

        _mapper.Map(updateCinemaRequest, price);
        await _repository.SaveAsync();
    }

    private async Task<Price> PriceExists(int id, bool trackChanges = false)
    {
        var price = await _repository.Price.GetPriceAsync(id, trackChanges);
        if (price is null)
        {
            _loggerManager.LogError(ConstError.ERROR_BY_ID);
            throw new NotFoundException(ConstError.GetErrorForException(nameof(Price), id));
        }

        return price;
    }
}
