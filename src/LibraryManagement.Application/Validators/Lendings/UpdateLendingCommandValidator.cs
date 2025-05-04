using FluentValidation;
using LibraryManagement.Application.Features.Lendings.Commands;

namespace LibraryManagement.Application.Validators.Lendings
{
    public class UpdateLendingCommandValidator : AbstractValidator<UpdateLendingCommand>
    {
        public UpdateLendingCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
} 