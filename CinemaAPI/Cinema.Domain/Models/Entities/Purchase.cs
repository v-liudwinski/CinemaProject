namespace Cinema.Domain.Models.Entities;

public class Purchase
{
    public int Id { get; set; }
    public DateTime PurchaseDate { get; set; }
    public decimal Price { get; set; }

    // Navigation property
    public int UserDetailsId { get; set; }
    public UserDetails UserDetails { get; set; }
    public int PromocodeId { get; set; }
    public Promocode Promocode { get; set; }
    public ICollection<Ticket> Tickets { get; set; }
}