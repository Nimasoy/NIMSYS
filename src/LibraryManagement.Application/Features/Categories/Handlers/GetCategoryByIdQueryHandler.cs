using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LibraryManagement.Application.DTOs;
using LibraryManagement.Application.Features.Categories.Queries;
using LibraryManagement.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LibraryManagement.Application.Features.Categories.Handlers
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetCategoryByIdQueryHandler> _logger;

        public GetCategoryByIdQueryHandler(
            ICategoryRepository categoryRepository,
            IMapper mapper,
            ILogger<GetCategoryByIdQueryHandler> logger)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);
            if (category == null)
            {
                _logger.LogWarning("Category not found: {CategoryId}", request.Id);
                throw new Exception($"Category with Id {request.Id} not found.");
            }
            var dto = _mapper.Map<CategoryDto>(category);
            return dto;
        }
    }
} 