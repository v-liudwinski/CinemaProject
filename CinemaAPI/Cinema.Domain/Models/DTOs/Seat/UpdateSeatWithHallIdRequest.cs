namespace Cinema.Domain.Models.DTOs;

public class UpdateSeatWithHallIdRequest
{
    public int SeatNumber { get; set; }
    public int Row { get; set; }
    public int SeatTypeId { get; set; }
    public int HallId { get; set; }
}
