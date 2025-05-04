using System;
using System.Threading;
using System.Threading.Tasks;
using LibraryManagement.Application.Features.Tags.Commands;
using LibraryManagement.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LibraryManagement.Application.Features.Tags.Handlers
{
    public class DeleteTagCommandHandler : IRequestHandler<DeleteTagCommand, Unit>
    {
        private readonly ITagRepository _tagRepository;
        private readonly ILogger<DeleteTagCommandHandler> _logger;

        public DeleteTagCommandHandler(ITagRepository tagRepository, ILogger<DeleteTagCommandHandler> logger)
        {
            _tagRepository = tagRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
        {
            var tag = await _tagRepository.GetByIdAsync(request.Id);
            if (tag == null)
            {
                _logger.LogWarning("Tag not found for delete: {TagId}", request.Id);
                throw new Exception($"Tag with Id {request.Id} not found.");
            }
            await _tagRepository.DeleteAsync(tag);
            _logger.LogInformation("Tag deleted: {TagId}", tag.Id);
            return Unit.Value;
        }
    }
} 