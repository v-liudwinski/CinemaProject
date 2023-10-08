namespace Cinema.Domain.Models.ViewModels;

public class GenreViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<MovieGenreViewModel> MovieGenres { get; set; }
}
