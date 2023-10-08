namespace Cinema.Domain.Models.ViewModels;

public class RefreshResponse
{
    public string NewJwtToken { get; set; }
    public string RefreshToken { get; set; }
}