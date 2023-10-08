using Cinema.Domain.Models.Entities;

namespace Cinema.Persistence.Interfaces;

public interface ISeatRepository
{
    Task<List<Seat>> GetAllSeatsAsync();
    Task<Seat?> GetSeatAsync(int id, bool trackChanges = false);
    Task<Seat?> GetSeatByNumberAndRowAsync(int num, int row, int hallId);
    void CreateSeat(Seat seat);
    void DeleteSeat(Seat seat);
}
