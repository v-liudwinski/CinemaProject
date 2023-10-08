namespace Cinema.Domain.Models.Entities;

public class Seanse
{
    public int Id { get; set; }
    public DateTime StartTime { get; set; }

    // Navigation property
    public int MovieId { get; set; }
    public Movie Movie { get; set; }
    public int HallId { get; set; }
    public Hall Hall { get; set; }
    public int PriceId { get; set; }
    public Price Price { get; set; }
}