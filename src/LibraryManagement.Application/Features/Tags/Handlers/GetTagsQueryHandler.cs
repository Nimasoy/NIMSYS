using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LibraryManagement.Application.DTOs;
using LibraryManagement.Application.Features.Tags.Queries;
using LibraryManagement.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LibraryManagement.Application.Features.Tags.Handlers
{
    public class GetTagsQueryHandler : IRequestHandler<GetTagsQuery, IEnumerable<TagDto>>
    {
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetTagsQueryHandler> _logger;

        public GetTagsQueryHandler(
            ITagRepository tagRepository,
            IMapper mapper,
            ILogger<GetTagsQueryHandler> logger)
        {
            _tagRepository = tagRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<TagDto>> Handle(GetTagsQuery request, CancellationToken cancellationToken)
        {
            var tags = await _tagRepository.GetAllAsync();
            var dtos = _mapper.Map<IEnumerable<TagDto>>(tags);
            return dtos;
        }
    }
} 