using FluentValidation;
using LibraryManagement.Application.Features.Users.Commands;

namespace LibraryManagement.Application.Validators.Users
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.UserName).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.MaxBorrowLimit).GreaterThan(0);
        }
    }
} 