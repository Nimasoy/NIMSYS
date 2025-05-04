using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LibraryManagement.Application.Features.Categories.Commands;
using LibraryManagement.Domain.Entities;
using LibraryManagement.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LibraryManagement.Application.Features.Categories.Handlers
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Unit>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateCategoryCommandHandler> _logger;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper, ILogger<UpdateCategoryCommandHandler> logger)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);
            if (category == null)
            {
                _logger.LogWarning("Category not found for update: {CategoryId}", request.Id);
                throw new Exception($"Category with Id {request.Id} not found.");
            }
            _mapper.Map(request, category);
            await _categoryRepository.UpdateAsync(category);
            _logger.LogInformation("Category updated: {CategoryId}", category.Id);
            return Unit.Value;
        }
    }
} 