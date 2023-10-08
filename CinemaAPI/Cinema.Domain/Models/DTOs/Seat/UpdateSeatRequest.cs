namespace Cinema.Domain.Models.DTOs;

public class UpdateSeatRequest
{
    public int SeatNumber { get; set; }
    public int Row { get; set; }
    public int SeatTypeId { get; set; }
}
