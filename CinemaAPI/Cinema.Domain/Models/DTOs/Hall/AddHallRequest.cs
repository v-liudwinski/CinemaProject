namespace Cinema.Domain.Models.DTOs;

public class AddHallRequest
{
    public int HallNumber { get; set; }
    public ICollection<AddSeatRequest> Seats { get; set; }
}
