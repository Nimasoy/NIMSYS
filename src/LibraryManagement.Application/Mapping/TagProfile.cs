using AutoMapper;
using LibraryManagement.Application.DTOs;
using LibraryManagement.Domain.Entities;

namespace LibraryManagement.Application.Mapping
{
    public class TagProfile : Profile
    {
        public TagProfile()
        {
            CreateMap<Tag, TagDto>();
            CreateMap<CreateTagDto, Tag>();
        }
    }
} 