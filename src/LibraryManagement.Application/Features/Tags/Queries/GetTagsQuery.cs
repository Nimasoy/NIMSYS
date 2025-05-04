using System.Collections.Generic;
using LibraryManagement.Application.DTOs;
using MediatR;

namespace LibraryManagement.Application.Features.Tags.Queries
{
    public class GetTagsQuery : IRequest<IEnumerable<TagDto>>
    {
    }
} 