using System.Text.Json.Serialization;

namespace Cinema.Domain.Models.Entities;

public class MovieDetails
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
    // Navigation property
    public int MovieId { get; set; }
    [JsonIgnore]
    public Movie Movie { get; set; }
    public ICollection<Review> Reviews { get; set; }
}