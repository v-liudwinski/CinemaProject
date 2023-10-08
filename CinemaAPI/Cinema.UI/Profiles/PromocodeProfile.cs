using AutoMapper;
using Cinema.Domain.Models.DTOs;
using Cinema.Domain.Models.Entities;
using Cinema.Domain.Models.ViewModels;

namespace Cinema.UI.Profiles;

public class PromocodeProfile : Profile
{
	public PromocodeProfile()
	{
        CreateMap<Promocode, PromocodeViewModel>()
            .ReverseMap();
        CreateMap<Promocode, AddPromocodeRequest>()
            .ReverseMap();
        CreateMap<Promocode, UpdatePromocodeRequest>()
            .ReverseMap();
        CreateMap<Promocode, string>()
            .ConvertUsing(x => x.Name);
    }
}
