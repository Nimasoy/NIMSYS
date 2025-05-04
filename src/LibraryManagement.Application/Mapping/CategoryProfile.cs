using AutoMapper;
using LibraryManagement.Application.DTOs;
using LibraryManagement.Domain.Entities;

namespace LibraryManagement.Application.Mapping
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>();
        }
    }
} 