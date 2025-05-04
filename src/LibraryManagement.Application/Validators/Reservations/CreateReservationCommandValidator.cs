using FluentValidation;
using LibraryManagement.Application.Features.Reservations.Commands;

namespace LibraryManagement.Application.Validators.Reservations
{
    public class CreateReservationCommandValidator : AbstractValidator<CreateReservationCommand>
    {
        public CreateReservationCommandValidator()
        {
            RuleFor(x => x.BookId).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.ReservedAt).NotEmpty();
            RuleFor(x => x.ExpiresAt).NotEmpty().GreaterThan(x => x.ReservedAt);
        }
    }
} 