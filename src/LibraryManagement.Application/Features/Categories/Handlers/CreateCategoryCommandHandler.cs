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
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Guid>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateCategoryCommandHandler> _logger;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper, ILogger<CreateCategoryCommandHandler> logger)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(request);
            category.Id = Guid.NewGuid();
            await _categoryRepository.AddAsync(category);
            _logger.LogInformation("Category created with Id: {CategoryId}", category.Id);
            return category.Id;
        }
    }
} 