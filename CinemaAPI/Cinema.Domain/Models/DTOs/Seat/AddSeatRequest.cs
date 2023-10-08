namespace Cinema.Domain.Models.DTOs;

public class AddSeatRequest
{
    public int SeatNumber { get; set; }
    public int Row { get; set; }
    public int SeatTypeId { get; set; }
}
