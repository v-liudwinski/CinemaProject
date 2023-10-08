using AutoMapper;
using Cinema.Domain.Models.DTOs;
using Cinema.Domain.Models.Entities;
using Cinema.Domain.Models.ViewModels;

namespace Cinema.UI.Profiles;

public class FavouriteProfile : Profile
{
    public FavouriteProfile()
    {
        CreateMap<Favourite, FavouriteViewModel>()
            .ReverseMap();
        CreateMap<Favourite, AddFavouriteRequest>()
            .ReverseMap();
    }
}
