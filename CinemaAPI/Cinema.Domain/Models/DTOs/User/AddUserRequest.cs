namespace Cinema.Domain.Models.DTOs;

public class AddUserRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Birthday { get; set; }
    public string PhoneNumber { get; set; }
}