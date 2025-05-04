using MediatR;
using System;

namespace LibraryManagement.Application.Features.Categories.Commands
{
    public class UpdateCategoryCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
    }
} 