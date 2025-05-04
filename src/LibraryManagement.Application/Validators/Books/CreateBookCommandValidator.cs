using FluentValidation;
using LibraryManagement.Application.Features.Books.Commands;

namespace LibraryManagement.Application.Validators.Books
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(200);
            RuleFor(x => x.Author).NotEmpty().MaximumLength(100);
            RuleFor(x => x.CategoryId).NotEmpty();
        }
    }
} 