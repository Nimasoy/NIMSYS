using System;
using System.Threading;
using System.Threading.Tasks;
using LibraryManagement.Application.Features.Categories.Commands;
using LibraryManagement.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LibraryManagement.Application.Features.Categories.Handlers
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Unit>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<DeleteCategoryCommandHandler> _logger;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, ILogger<DeleteCategoryCommandHandler> logger)
        {
            _categoryRepository = categoryRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);
            if (category == null)
            {
                _logger.LogWarning("Category not found for delete: {CategoryId}", request.Id);
                throw new Exception($"Category with Id {request.Id} not found.");
            }
            await _categoryRepository.DeleteAsync(category);
            _logger.LogInformation("Category deleted: {CategoryId}", category.Id);
            return Unit.Value;
        }
    }
} 