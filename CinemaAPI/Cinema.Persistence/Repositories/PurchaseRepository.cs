using Cinema.Domain.Models.Entities;
using Cinema.Domain.RequestFeatures;
using Cinema.Persistence.Data;
using Cinema.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Persistence.Repositories;

public class PurchaseRepository : RepositoryBase<Purchase>, IPurchaseRepository
{
    public PurchaseRepository(RepositoryContext repositoryContext) 
        : base(repositoryContext)
    { }

    public void CreatePurchase(Purchase purchase)
    {
        Create(purchase);
    }

    public void DeletePurchase(Purchase purchase)
    {
        Delete(purchase);
    }

    public async Task<PagedList<Purchase>> GetAllPurchasesAsync(PurchaseParameters purchaseParameters)
    {
        var purchases = await FindAll()
            .OrderByDescending(x => x.PurchaseDate)
            .Skip((purchaseParameters.PageNumber - 1) * purchaseParameters.PageSize)
            .Take(purchaseParameters.PageSize)
            .ToListAsync();

        var count = await FindAll().CountAsync();
        return new PagedList<Purchase>(purchases, count, purchaseParameters.PageNumber, purchaseParameters.PageSize);
    }

    public async Task<Purchase?> GetPurchaseAsync(int id, bool trackChanges = false)
    {
        return await FindByCondition(x => x.Id == id, trackChanges)
            .Include(x => x.Promocode)
            .Include(x => x.Tickets)
                .ThenInclude(x => x.Seat)
                    .ThenInclude(x => x.SeatType)
            .Include(x => x.Tickets)
                .ThenInclude(x => x.Seanse)
                    .ThenInclude(x => x.Movie)
            .Include(x => x.Tickets)
                .ThenInclude(x => x.Seanse)
                    .ThenInclude(x => x.Price)
            .FirstOrDefaultAsync();
    }

    public async Task<List<Purchase>> GetAllPurchaseByUserDetailsIdAsync(int id)
    {
        return await FindAll()
            .Where(x => x.UserDetailsId == id)
            .Include(x => x.Promocode)
            .Include(x => x.Tickets)
                .ThenInclude(x => x.Seat)
                    .ThenInclude(x => x.SeatType)
            .Include(x => x.Tickets)
                .ThenInclude(x => x.Seanse)
                    .ThenInclude(x => x.Movie)
            .Include(x => x.Tickets)
                .ThenInclude(x => x.Seanse)
                    .ThenInclude(x => x.Price)
            .ToListAsync();
    }
}
