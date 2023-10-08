using AutoMapper;
using Cinema.Domain.Models.DTOs;
using Cinema.Domain.Models.Entities;
using Cinema.Domain.Models.ViewModels;

namespace Cinema.UI.Profiles;

public class PurchaseProfile : Profile
{
    public PurchaseProfile()
    {
        CreateMap<AddPurchaseRequest, Purchase>()
            .ForMember(x => x.Promocode, opt => opt.Ignore());
        CreateMap<Purchase, PurchaseViewModel>();
        CreateMap<Purchase, PurchaseViewModelShort>();
    }
}
