namespace Cinema.Domain.Models.Entities;

public class Movie
{
    public int Id { get; set; }
    public string OriginalTitle { get; set; }
    public string Title { get; set; }
    public int Duration { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string PosterUrl { get; set; }
    // Navigation property
    public int MovieTypeId { get; set; }
    public MovieType MovieType { get; set; }
    public MovieDetails MovieDetails { get; set; }
    public ICollection<MovieGenre> MovieGenres { get; set; }
    public ICollection<Favourite> Favourites { get; set; }
}