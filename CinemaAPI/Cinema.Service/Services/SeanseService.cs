using AutoMapper;
using Cinema.Domain.ExceptionModels;
using Cinema.Domain.Models.Consts;
using Cinema.Domain.Models.DTOs;
using Cinema.Domain.Models.Entities;
using Cinema.Domain.Models.ViewModels;
using Cinema.Domain.RequestFeatures;
using Cinema.Persistence.Interfaces;
using Cinema.Service.Interfaces;


namespace Cinema.Service.Services;

public class SeanseService : ISeanseService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _loggerManager;
    private readonly IMapper _mapper;

    public SeanseService(IRepositoryManager repository, ILoggerManager loggerManager, IMapper mapper)
    {
        _repository = repository;        
        _loggerManager = loggerManager;
        _mapper = mapper;
    }
    public async Task<SeanseViewModel> AddAsync(AddSeanseRequest addSeanseRequest)
    {
        var seanse = _mapper.Map<Seanse>(addSeanseRequest);

        _repository.Seanse.CreateSeanse(seanse);
        await _repository.SaveAsync();

        return _mapper.Map<SeanseViewModel>(seanse);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.Seanse.DeleteSeanseAsync(id);
        await _repository.SaveAsync();
    }

    public async Task<(IEnumerable<SeanseViewModel> seanses, MetaData metaData)> GetAllAsync(
        SeanseParameters seanseParameters)
    {
        var seansesWithMediaData = await _repository.Seanse.GetAllSeanseAsync(seanseParameters);

        var seansesToReturn = _mapper.Map<IEnumerable<SeanseViewModel>>(seansesWithMediaData);

        return (seanses: seansesToReturn, metaData: seansesWithMediaData.MetaData);
    }

    public async Task<SeanseInfoViewModel> GetAsync(int id)
    {
        var seanse = await SeanseExists(id);

        return _mapper.Map<SeanseInfoViewModel>(seanse);
    }

    public async Task UpdateAsync(int id, UpdateSeanseRequest updateSeanseRequest)
    {
        var seanse = await SeanseExists(id, true);

        _mapper.Map(updateSeanseRequest, seanse);
        await _repository.SaveAsync();
    }

    private async Task<Seanse> SeanseExists(int id, bool trackChanges = false)
    {
        var seanse = await _repository.Seanse.GetSeanseAsync(id, trackChanges);
        if (seanse is null)
        {
            _loggerManager.LogError(ConstError.ERROR_BY_ID);
            throw new NotFoundException(ConstError.GetErrorForException(nameof(Seanse), id));
        }

        return seanse;
    }
}
