using AutoMapper;
using Cinema.Domain.Models.DTOs;
using Cinema.Domain.Models.Entities;
using Cinema.Domain.Models.ViewModels;

namespace Cinema.UI.Profiles;

public class SeanseProfile : Profile
{
    public SeanseProfile()
    {
        CreateMap<Seanse, SeanseViewModel>()
            .ReverseMap();
        CreateMap<Seanse, AddSeanseRequest>()
            .ReverseMap();
        CreateMap<Seanse, UpdateSeanseRequest>()
            .ReverseMap();
        CreateMap<Seanse, SeanseInfoViewModel>();
    }
}
