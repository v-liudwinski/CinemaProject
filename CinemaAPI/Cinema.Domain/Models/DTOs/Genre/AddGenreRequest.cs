namespace Cinema.Domain.Models.DTOs;

public class AddGenreRequest
{
    public string Name { get; set; }
    public ICollection<AddMovieGerneRequest> GenreRequests { get; set; }
}
