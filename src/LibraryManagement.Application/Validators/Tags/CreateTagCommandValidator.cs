using FluentValidation;
using LibraryManagement.Application.Features.Tags.Commands;

namespace LibraryManagement.Application.Validators.Tags
{
    public class CreateTagCommandValidator : AbstractValidator<CreateTagCommand>
    {
        public CreateTagCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
        }
    }
} 