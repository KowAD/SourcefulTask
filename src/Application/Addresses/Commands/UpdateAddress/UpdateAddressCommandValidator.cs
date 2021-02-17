using FluentValidation;

namespace SourcefulTask.Application.Addresses.Commands.UpdateAddress
{
    public class UpdateAddressCommandValidator : AbstractValidator<UpdateAddressCommand>
    {
        public UpdateAddressCommandValidator()
        {
            RuleFor(v => v.Street)
                .MaximumLength(60)
                .NotEmpty();

            RuleFor(v => v.City)
                .MaximumLength(60)
                .NotEmpty();

            RuleFor(v => v.PostCode)
                .MaximumLength(11);
        }
    }
}
