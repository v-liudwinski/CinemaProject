namespace Cinema.Domain.Models.DTOs.Movie;

public class UpdateMovieDetailsRequest
{
    public string Description { get; set; }
    public string Producers { get; set; }
    public int AgeLimit { get; set; }
    public double IndependentRate { get; set; }
    public string Country { get; set; }
    public string MovieTrailerUrl { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
