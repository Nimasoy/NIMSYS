using FluentValidation;
using LibraryManagement.Application.Features.Categories.Commands;

namespace LibraryManagement.Application.Validators.Categories
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        }
    }
} 