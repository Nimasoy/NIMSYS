using AutoMapper;
using LibraryManagement.Application.DTOs;
using LibraryManagement.Domain.Entities;
using LibraryManagement.Domain.Enums;

namespace LibraryManagement.Application.Mapping
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category != null ? src.Category.Name : string.Empty))
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags != null ? src.Tags.Select(t => t.Name).ToList() : new List<string>()))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));

            CreateMap<CreateBookDto, Book>();
            CreateMap<UpdateBookDto, Book>();
        }
    }
} 