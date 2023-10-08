using Cinema.Domain.Models.Entities;
using Cinema.Domain.RequestFeatures;
using Cinema.Persistence.Data;
using Cinema.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Persistence.Repositories;

public class SeanseRepository : RepositoryBase<Seanse>, ISeanseRepository
{
    public SeanseRepository(RepositoryContext repositoryContext) 
        : base(repositoryContext)
    { }

    public async Task DeleteSeanseAsync(int id)
    {
        var seanse = await _repositoryContext.Seanses!
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
        if (seanse is not null) _repositoryContext.Remove(seanse);;
    }

    public void CreateSeanse(Seanse seanse)
    {
        Create(seanse);
    }
    
    public void DeleteSeanse(Seanse seanse)
    {
        Delete(seanse);
    }

    public async Task<PagedList<Seanse>> GetAllSeanseAsync(SeanseParameters seanseParameters)
    {
        var seanses = await FindAll()
            .Include(x => x.Movie)
            .Include(x => x.Hall)
                .ThenInclude(x => x.Seats)
                    .ThenInclude(x => x.SeatType)
            .Include(x => x.Price)
            .OrderBy(x => x.Id)
            .Skip((seanseParameters.PageNumber - 1) * seanseParameters.PageSize)
            .Take(seanseParameters.PageSize)
            .ToListAsync();

        var count = await FindAll().CountAsync();
        return new PagedList<Seanse>(seanses, count, seanseParameters.PageNumber, seanseParameters.PageSize);
    }

    public async Task<Seanse?> GetSeanseAsync(int id, bool trackChanges = false)
    {
        return await FindByCondition(x => x.Id == id, trackChanges)
            .Include(x => x.Movie)
            .Include(x => x.Hall)
                .ThenInclude(x => x.Seats)
                    .ThenInclude(x => x.SeatType)
            .Include(x => x.Price)
            .OrderBy(x => x.Id)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}
