using MediatR;
using System;

namespace LibraryManagement.Application.Features.Categories.Commands
{
    public class CreateCategoryCommand : IRequest<Guid>
    {
        public required string Name { get; set; }
    }
} 