namespace Cinema.Domain.Models.ViewModels;

public class SeatViewModel
{
    public int Id { get; set; }
    public int SeatNumber { get; set; }
    public int Row { get; set; }
    public SeatTypeViewModel SeatType { get; set; }
}
