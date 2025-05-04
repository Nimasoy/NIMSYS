using FluentValidation;
using LibraryManagement.Application.Features.Categories.Commands;

namespace LibraryManagement.Application.Validators.Categories
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        }
    }
} 