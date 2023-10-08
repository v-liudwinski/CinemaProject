using Cinema.Domain.Models.Entities;

namespace Cinema.Persistence.Interfaces;

public interface IHallRepository
{
    Task<List<Hall>> GetAllHallInfoAsync();
    Task<List<Hall>> GetAllHallByCinemaIdAsync(int cinemaId);
    Task<Hall?> GetHallInfoAsync(int id);
    Task<Hall?> GetHallByNumberAsync(int num);
    Task<Hall?> GetHallAsync(int id, bool trackChanges = false);
    void CreateHall(Hall hall);
    void DeleteHall(Hall hall);
}
