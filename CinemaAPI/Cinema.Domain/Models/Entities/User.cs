namespace Cinema.Domain.Models.Entities;

public class User
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Birthday { get; set; }
    public string PhoneNumber { get; set; }
    
    // Navigation property
    public int RoleId { get; set; }
    public Role Role { get; set; }
    public UserDetails UserDetails { get; set; }
    public UserRefreshToken? UserRefreshToken { get; set; }
}