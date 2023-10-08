namespace Cinema.Service.Interfaces;

public interface IPdfService
{
    Task<byte[]> GetTicket(int id);
}
