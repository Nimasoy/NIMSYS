using AutoMapper;
using LibraryManagement.Application.DTOs;
using LibraryManagement.Domain.Entities;

namespace LibraryManagement.Application.Mapping
{
    public class ReservationProfile : Profile
    {
        public ReservationProfile()
        {
            CreateMap<Reservation, ReservationDto>()
                .ForMember(dest => dest.BookTitle, opt => opt.MapFrom(src => src.Book != null ? src.Book.Title : string.Empty))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User != null ? src.User.UserName : string.Empty));
        }
    }
} 