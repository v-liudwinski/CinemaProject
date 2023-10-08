namespace Cinema.Domain.Models.DTOs;

public class UpdateCinemaRequest
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}