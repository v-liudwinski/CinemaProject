using AutoMapper;
using Cinema.Domain.Models.DTOs;
using Cinema.Domain.Models.ViewModels;

namespace Cinema.UI.Profiles;

public class CinemaProfile : Profile
{
    public CinemaProfile()
    {
        CreateMap<Domain.Models.Entities.Cinema, CinemaInfoViewModel>().ReverseMap();
        CreateMap<Domain.Models.Entities.Cinema, CinemaViewModel>().ReverseMap();
        CreateMap<AddCinemaRequest, Domain.Models.Entities.Cinema>();
        CreateMap<UpdateCinemaRequest, Domain.Models.Entities.Cinema>();
    }
}