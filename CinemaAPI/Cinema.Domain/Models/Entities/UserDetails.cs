namespace Cinema.Domain.Models.Entities;

public class UserDetails
{
    public int Id { get; set; }
    public string AvatarUrl { get; set; }
    
    // Navigation property
    public int UserId { get; set; }
    public User User { get; set; }
    public ICollection<Review> Reviews { get; set; }
    public ICollection<Favourite> Favourites { get; set; }
    public ICollection<Purchase> Purchase { get; set; }
}