namespace Cinema.Domain.Models.DTOs;

public class UpdateMovieGenreRequest
{
    public int MovieId { get; set; }
    public int GenreId { get; set; }
}
