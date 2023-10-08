namespace Cinema.Domain.Models.Entities;

public class Cinema
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }

    // Navigation property
    public ICollection<Hall> Halls { get; set; }
}