namespace Cinema.Domain.Models.DTOs;

public class AddSeatWithHallIdRequest
{
    public int SeatNumber { get; set; }
    public int Row { get; set; }
    public int SeatTypeId { get; set; }
    public int HallId { get; set; }
}
