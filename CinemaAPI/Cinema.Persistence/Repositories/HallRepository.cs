using Cinema.Domain.Models.Entities;
using Cinema.Persistence.Data;
using Cinema.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Persistence.Repositories;

public class HallRepository : RepositoryBase<Hall>, IHallRepository
{
    public HallRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    { }

    public async Task<Hall?> GetHallAsync(int id, bool trackChanges = false)
    {
        return await FindByCondition(x => x.Id == id, trackChanges)
            .FirstOrDefaultAsync();
    }

    public void CreateHall(Hall hall)
    {
        Create(hall);
    }

    public void DeleteHall(Hall hall)
    {
        Delete(hall);
    }

    public async Task<List<Hall>> GetAllHallInfoAsync()
    {
        return await FindAll()
            .Include(x => x.Seats)
                .ThenInclude(x => x.SeatType)
            .ToListAsync();
    }

    public async Task<List<Hall>> GetAllHallByCinemaIdAsync(int cinemaId)
    {
        return await FindByCondition(x => x.CinemaId == cinemaId, false)
            .ToListAsync();
    }

    public async Task<Hall?> GetHallInfoAsync(int id)
    {
        return await FindByCondition(x => x.Id == id, false)
            .Include(x => x.Seats)
                .ThenInclude(x => x.SeatType)
            .FirstOrDefaultAsync(x => x.Id == id);
        }

    public async Task<Hall?> GetHallByNumberAsync(int num)
    {
        return await FindByCondition(x => x.HallNumber == num, false)
            .FirstOrDefaultAsync();
    }
}
