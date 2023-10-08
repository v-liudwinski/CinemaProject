namespace Cinema.Domain.Models.ViewModels;

public class TicketViewModel
{
    public int Id { get; set; }

    // Navigation property
    public SeanseViewModel Seanse { get; set; }
    public SeatViewModel Seat { get; set; }
    public decimal Price { get; set; }
}
