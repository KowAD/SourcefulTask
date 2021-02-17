using FluentValidation;

namespace SourcefulTask.Application.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommand>
    {
        public UpdateEmployeeCommandValidator()
        {
            RuleFor(v => v.FirstName)
                .MaximumLength(60)
                .NotEmpty();

            RuleFor(v => v.LastName)
                .MaximumLength(60)
                .NotEmpty();

            RuleFor(v => v.Pesel)
                .MaximumLength(11);

            RuleFor(v => v.Email)
                .EmailAddress()
                .WithMessage("A valid email address is required.");
        }
    }
}
