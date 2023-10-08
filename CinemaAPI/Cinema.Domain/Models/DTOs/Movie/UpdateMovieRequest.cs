using Cinema.Domain.Models.DTOs.Movie;

namespace Cinema.Domain.Models.DTOs;

public class UpdateMovieRequest
{
    public string OriginalTitle { get; set; }
    public string Title { get; set; }
    public int Duration { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string PosterUrl { get; set; }
    public int MovieTypeId { get; set; }
    public UpdateMovieDetailsRequest MovieDetails { get; set; }
}
