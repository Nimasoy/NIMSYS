using MediatR;
using System;

namespace LibraryManagement.Application.Features.Categories.Commands
{
    public class DeleteCategoryCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
} 