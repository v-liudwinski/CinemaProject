using Cinema.Domain.Models.Entities;

namespace Cinema.Domain.Models.ViewModels;

public class MovieDetailsViewModel
{
    public int Id { get; set; }
    public string Description { get; set; }
    public string Producers { get; set; }
    public int AgeLimit { get; set; }
    public double IndependentRate { get; set; }
    public double UsersRate { get; set; }
    public string Country { get; set; }
    public string MovieTrailerUrl { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }    
}
