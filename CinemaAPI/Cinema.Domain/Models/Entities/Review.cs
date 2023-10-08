namespace Cinema.Domain.Models.Entities;

public class Review
{
    public int Id { get; set; }
    public string Description { get; set; }
    public double Rate { get; set; }
    // Navigation property
    public int MovieDetailsId { get; set; }
    public MovieDetails MovieDetails { get; set; }
    public int UserDetailsId { get; set; }
    public UserDetails UserDetails { get; set; }
}