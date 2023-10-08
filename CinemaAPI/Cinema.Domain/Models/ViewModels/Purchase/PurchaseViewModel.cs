namespace Cinema.Domain.Models.ViewModels;

public class PurchaseViewModel
{
    public int Id { get; set; }
    public DateTime PurchaseDate { get; set; }
    public decimal Price { get; set; }

    // Navigation property
    public int UserDetailsId { get; set; }
    public string Promocode { get; set; }
    public ICollection<TicketViewModel> Tickets { get; set; }
}
