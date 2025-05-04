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
    public class GetLendingByIdQueryHandler : IRequestHandler<GetLendingByIdQuery, LendingDto>
    {
        private readonly ILendingRepository _lendingRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetLendingByIdQueryHandler> _logger;

        public GetLendingByIdQueryHandler(
            ILendingRepository lendingRepository,
            IMapper mapper,
            ILogger<GetLendingByIdQueryHandler> logger)
        {
            _lendingRepository = lendingRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<LendingDto> Handle(GetLendingByIdQuery request, CancellationToken cancellationToken)
        {
            var lending = await _lendingRepository.GetByIdAsync(request.Id);
            if (lending == null)
            {
                _logger.LogWarning("Lending not found: {LendingId}", request.Id);
                throw new Exception($"Lending with Id {request.Id} not found.");
            }
            var dto = _mapper.Map<LendingDto>(lending);
            return dto;
        }
    }
} 