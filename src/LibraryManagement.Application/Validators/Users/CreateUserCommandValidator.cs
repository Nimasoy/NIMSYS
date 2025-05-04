using FluentValidation;
using LibraryManagement.Application.Features.Users.Commands;

namespace LibraryManagement.Application.Validators.Users
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty().MinimumLength(6);
            RuleFor(x => x.MaxBorrowLimit).GreaterThan(0);
        }
    }
} 