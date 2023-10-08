namespace Cinema.Domain.Models.ViewModels;

public class HallInfoViewModel
{
    public int Id { get; set; }
    public int HallNumber { get; set; }
    public ICollection<SeatViewModel> Seats { get; set; }
}
