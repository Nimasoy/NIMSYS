using MediatR;
using System;

namespace LibraryManagement.Application.Features.Tags.Commands
{
    public class DeleteTagCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
} 