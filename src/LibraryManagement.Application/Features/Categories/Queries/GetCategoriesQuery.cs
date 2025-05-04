using System.Collections.Generic;
using LibraryManagement.Application.DTOs;
using MediatR;

namespace LibraryManagement.Application.Features.Categories.Queries
{
    public class GetCategoriesQuery : IRequest<IEnumerable<CategoryDto>>
    {
    }
} 