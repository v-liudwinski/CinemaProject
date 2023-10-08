namespace Cinema.Domain.Models.Entities;

public class Hall
{
    public int Id { get; set; }
    public int HallNumber { get; set; }

    // Navigation property
    public int CinemaId { get; set; }
    public ICollection<Seat> Seats { get; set; }
}