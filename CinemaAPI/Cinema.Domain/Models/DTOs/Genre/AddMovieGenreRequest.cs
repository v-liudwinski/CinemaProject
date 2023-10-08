using Cinema.Domain.Models.Entities;

namespace Cinema.Domain.Models.DTOs;

public class AddMovieGenreRequest
{
    public int MovieId { get; set; }    
    public int GenreId { get; set; }   
}
