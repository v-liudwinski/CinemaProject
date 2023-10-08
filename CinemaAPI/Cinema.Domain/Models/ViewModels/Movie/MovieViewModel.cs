using Cinema.Domain.Models.Entities;

namespace Cinema.Domain.Models.ViewModels;

public class MovieViewModel
{
    public int Id { get; set; }
    public string OriginalTitle { get; set; }
    public string Title { get; set; }
    public int Duration { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string PosterUrl { get; set; }
}
