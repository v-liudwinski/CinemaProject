using AutoMapper;
using Cinema.Domain.Models.DTOs;
using Cinema.Domain.Models.Entities;
using Cinema.Domain.Models.ViewModels;

namespace Cinema.UI.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserViewModel>()
            .ForMember(x => x.RoleName, x => x.MapFrom(x => x.Role));
        CreateMap<User, AddUserRequest>()
            .ReverseMap();
        CreateMap<User, UpdateUserRequest>()
            .ReverseMap();
        CreateMap<User, UserInfoViewModel>()
            .ForMember(x => x.RoleName, x => x.MapFrom(x => x.Role));
        CreateMap<UserDetailsViewModel, UserDetails>()
            .ReverseMap();
        CreateMap<Role, string>()
            .ConvertUsing(x => x.RoleName.ToString());
    }
}