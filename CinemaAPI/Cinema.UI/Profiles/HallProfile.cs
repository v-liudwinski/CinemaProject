using AutoMapper;
using Cinema.Domain.Models.DTOs;
using Cinema.Domain.Models.Entities;
using Cinema.Domain.Models.ViewModels;

namespace Cinema.UI.Profiles;

public class HallProfile : Profile
{
    public HallProfile()
    {
        CreateMap<HallInfoViewModel, Hall>().ReverseMap();
        CreateMap<AddHallRequest, Hall>();
        CreateMap<UpdateHallRequest, Hall>();
        CreateMap<AddHallWithCinemaIdRequest, Hall>();
        CreateMap<UpdateHallWithCinemaIdRequest, Hall>();
    }
}
