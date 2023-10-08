namespace Cinema.Domain.Models.DTOs;

public class AddPurchaseRequest
{
    public int UserDetailsId { get; set; }
    public string Promocode { get; set; }
    public ICollection<AddTicketRequest> Tickets { get; set; }
}
