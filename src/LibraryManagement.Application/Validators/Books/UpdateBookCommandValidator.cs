using FluentValidation;
using LibraryManagement.Application.Features.Books.Commands;

namespace LibraryManagement.Application.Validators.Books
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Title).NotEmpty().MaximumLength(200);
            RuleFor(x => x.Author).NotEmpty().MaximumLength(100);
            RuleFor(x => x.CategoryId).NotEmpty();
        }
    }
} 