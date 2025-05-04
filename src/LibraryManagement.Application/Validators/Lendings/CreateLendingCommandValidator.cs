using FluentValidation;
using LibraryManagement.Application.Features.Lendings.Commands;

namespace LibraryManagement.Application.Validators.Lendings
{
    public class CreateLendingCommandValidator : AbstractValidator<CreateLendingCommand>
    {
        public CreateLendingCommandValidator()
        {
            RuleFor(x => x.BookId).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.BorrowedAt).NotEmpty();
            RuleFor(x => x.DueAt).NotEmpty().GreaterThan(x => x.BorrowedAt);
        }
    }
}
