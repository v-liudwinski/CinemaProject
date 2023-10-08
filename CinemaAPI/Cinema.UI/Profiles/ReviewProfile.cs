using AutoMapper;
using Cinema.Domain.Models.DTOs;
using Cinema.Domain.Models.Entities;
using Cinema.Domain.Models.ViewModels;

namespace Cinema.UI.Profiles;

public class ReviewProfile : Profile
{
    public ReviewProfile()
    {
        CreateMap<Review, ReviewViewModel>()
            .ReverseMap();
        CreateMap<Review, AddReviewRequest>()
            .ReverseMap();
        CreateMap<Review, UpdateReviewRequest>()
            .ReverseMap();
    }
}
