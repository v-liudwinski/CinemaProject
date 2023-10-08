using Cinema.Domain.Models.Entities;
using Cinema.Persistence.Data;
using Cinema.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Persistence.Repositories;

public class PriceRepository : RepositoryBase<Price>, IPriceRepository
{
    public PriceRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    { }

    public void CreatePrice(Price price)
    {
        Create(price);
    }

    public void DeletePrice(Price price)
    {
        Delete(price);
    }

    public async Task<List<Price>> GetAllPricesAsync()
    {
        return await FindAll()
            .OrderBy(x => x.Id)
            .ToListAsync();
    }

    public async Task<Price?> GetPriceAsync(int id, bool trackChanges = false)
    {
        return await FindByCondition(x => x.Id == id, trackChanges)
            .FirstOrDefaultAsync();
    }
}