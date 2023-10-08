namespace Cinema.Domain.Models.DTOs;

public class AddReviewRequest
{
    public string Description { get; set; }
    public double Rate { get; set; }
    public int MovieDetailsId { get; set; }
    public int UserDetailsId { get; set; }
}