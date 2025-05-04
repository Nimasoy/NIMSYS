using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LibraryManagement.Application.Features.Tags.Commands;
using LibraryManagement.Domain.Entities;
using LibraryManagement.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LibraryManagement.Application.Features.Tags.Handlers
{
    public class CreateTagCommandHandler : IRequestHandler<CreateTagCommand, Guid>
    {
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateTagCommandHandler> _logger;

        public CreateTagCommandHandler(ITagRepository tagRepository, IMapper mapper, ILogger<CreateTagCommandHandler> logger)
        {
            _tagRepository = tagRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Guid> Handle(CreateTagCommand request, CancellationToken cancellationToken)
        {
            var tag = _mapper.Map<Tag>(request);
            tag.Id = Guid.NewGuid();
            await _tagRepository.AddAsync(tag);
            _logger.LogInformation("Tag created with Id: {TagId}", tag.Id);
            return tag.Id;
        }
    }
} 