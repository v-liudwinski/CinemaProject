namespace Cinema.Domain.Models.Entities;

public class Genre
{
    public int Id { get; set; }
    public string Name { get; set; }
    // Navigation property
    public ICollection<MovieGenre> MovieGenres { get; set; }
}