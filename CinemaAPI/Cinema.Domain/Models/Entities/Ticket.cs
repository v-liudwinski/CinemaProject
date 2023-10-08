namespace Cinema.Domain.Models.Entities;

public class Ticket
{
    public int Id { get; set; }

    // Navigation property

    public int PurchaseId { get; set; }
    public Purchase Purchase { get; set; }
    public int SeanseId { get; set; }
    public Seanse Seanse { get; set; }
    public int SeatId { get; set; }
    public Seat Seat { get; set; }
    public decimal Price { get; set; }
}