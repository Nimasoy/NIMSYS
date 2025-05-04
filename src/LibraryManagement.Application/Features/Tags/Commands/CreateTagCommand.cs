using MediatR;
using System;

namespace LibraryManagement.Application.Features.Tags.Commands
{
    public class CreateTagCommand : IRequest<Guid>
    {
        public required string Name { get; set; }
    }
} 