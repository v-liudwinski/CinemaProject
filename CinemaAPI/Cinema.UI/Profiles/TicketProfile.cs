using AutoMapper;
using Cinema.Domain.Models.DTOs;
using Cinema.Domain.Models.Entities;
using Cinema.Domain.Models.ViewModels;

namespace Cinema.UI.Profiles;

public class TicketProfile : Profile
{
    public TicketProfile()
    {
        CreateMap<AddTicketRequest, Ticket>();
        CreateMap<Ticket, TicketViewModel>();
    }
}
