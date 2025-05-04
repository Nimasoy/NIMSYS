using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LibraryManagement.Application.DTOs;
using LibraryManagement.Application.Features.Lendings.Queries;
using LibraryManagement.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LibraryManagement.Application.Features.Lendings.Handlers
{
    public class GetLendingsQueryHandler : IRequestHandler<GetLendingsQuery, IEnumerable<LendingDto>>
    {
        private readonly ILendingRepository _lendingRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetLendingsQueryHandler> _logger;

        public GetLendingsQueryHandler(
            ILendingRepository lendingRepository,
            IMapper mapper,
            ILogger<GetLendingsQueryHandler> logger)
        {
            _lendingRepository = lendingRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<LendingDto>> Handle(GetLendingsQuery request, CancellationToken cancellationToken)
        {
            var lendings = await _lendingRepository.GetAllAsync();
            var dtos = _mapper.Map<IEnumerable<LendingDto>>(lendings);
            return dtos;
        }
    }
} 