using FluentValidation;

namespace SourcefulTask.Application.Addresses.Commands.CreateAddress
{
    public class CreateAddressCommandValidator : AbstractValidator<CreateAddressCommand>
    {
        public CreateAddressCommandValidator()
        {
            RuleFor(v => v.Street)
                .MaximumLength(60)
                .NotEmpty();

            RuleFor(v => v.City)
                .MaximumLength(60)
                .NotEmpty();

            RuleFor(v => v.PostCode)
                .MaximumLength(6);
        }
    }
}
