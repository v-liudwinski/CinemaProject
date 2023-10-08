using AutoMapper;
using Cinema.Domain.Models.DTOs;
using Cinema.Domain.Models.Entities;
using Cinema.Domain.Models.ViewModels;

namespace Cinema.UI.Profiles;

public class SeatProfile : Profile
{
    public SeatProfile()
    {
        CreateMap<SeatViewModel, Seat>().ReverseMap();
        CreateMap<AddSeatRequest, Seat>();
        CreateMap<UpdateSeatRequest, Seat>();
        CreateMap<AddSeatWithHallIdRequest, Seat>();
        CreateMap<UpdateSeatWithHallIdRequest, Seat>();
        CreateMap<SeatType, SeatTypeViewModel>()
            .ForMember(x => x.Type, x => x.ToString());
    }
}
