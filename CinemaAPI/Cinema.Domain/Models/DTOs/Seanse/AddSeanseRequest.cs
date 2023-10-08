using Cinema.Domain.Models.Entities;

namespace Cinema.Domain.Models.DTOs;

public class AddSeanseRequest
{
    public DateTime StartTime { get; set; }
    public int MovieId { get; set; }
    public int HallId { get; set; }
    public int PriceId { get; set; }
}
