namespace Cinema.Domain.Models.DTOs;

public class AddFavouriteRequest
{
    public int UserDetailsId { get; set; }
    public int MovieId { get; set; }
}