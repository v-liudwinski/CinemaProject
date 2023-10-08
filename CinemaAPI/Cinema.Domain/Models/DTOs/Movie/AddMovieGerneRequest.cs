using Cinema.Domain.Models.Entities;

namespace Cinema.Domain.Models.DTOs;

public class AddMovieGerneRequest
{
    public int MovieId { get; set; }    
    public int GenreId { get; set; }   
}
