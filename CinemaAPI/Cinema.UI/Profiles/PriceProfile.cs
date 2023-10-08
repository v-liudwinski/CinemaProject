using AutoMapper;
using Cinema.Domain.Models.DTOs;
using Cinema.Domain.Models.Entities;
using Cinema.Domain.Models.ViewModels;

namespace Cinema.UI.Profiles;

public class PriceProfile : Profile
{
    public PriceProfile()
    {
        CreateMap<PriceViewModel, Price>().ReverseMap();
        CreateMap<AddPriceRequest, Price>();
        CreateMap<UpdatePriceRequest, Price>();
    }
}
