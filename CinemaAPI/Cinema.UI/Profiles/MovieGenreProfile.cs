using AutoMapper;
using Cinema.Domain.Models.DTOs;
using Cinema.Domain.Models.ViewModels;
using Cinema.Domain.Models.Entities;

namespace Cinema.UI.Profiles;

public class MovieGenreProfile : Profile
{
	public MovieGenreProfile()
	{
        CreateMap<MovieGenre, MovieGenreViewModel>()
            .ForMember(x => x.Genre, x => x.MapFrom(x => x.Genre.Name));
        CreateMap<AddMovieGenreRequest, MovieGenre>()
            .ReverseMap();
        CreateMap<UpdateMovieGenreRequest, MovieGenre>()
            .ReverseMap();   
    }
}
