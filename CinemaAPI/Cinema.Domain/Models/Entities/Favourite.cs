namespace Cinema.Domain.Models.Entities;

public class Favourite
{
    public int UserDetailsId { get; set; }
    public UserDetails UserDetails { get; set; }
    public int MovieId { get; set; }
    public Movie Movie { get; set; }
}