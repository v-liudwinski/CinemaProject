namespace Cinema.Domain.Models.ViewModels;

public class MovieInfoViewModel
{
    public int Id { get; set; }
    public string OriginalTitle { get; set; }
    public string Title { get; set; }
    public int Duration { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string PosterUrl { get; set; }  
    public string MovieType { get; set; } 
    public MovieDetailsViewModel MovieDetails { get; set; }
    public ICollection<MovieGenreViewModel> MovieGenres { get; set; }
}
