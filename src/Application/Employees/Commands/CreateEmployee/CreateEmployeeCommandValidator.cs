using FluentValidation;

namespace SourcefulTask.Application.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeCommandValidator()
        {
            RuleFor(v => v.FirstName)
                .MaximumLength(60).WithMessage("FirstName must not exceed 60 characters.")
                .NotEmpty().WithMessage("FirstName is required.");

            RuleFor(v => v.LastName)
                .MaximumLength(60).WithMessage("LastName must not exceed 60 characters.")
                .NotEmpty().WithMessage("LastName is required.");

            RuleFor(v => v.Pesel)
                .MaximumLength(11).WithMessage("Pesel must not exceed 11 characters.");

            RuleFor(v => v.Email)
                .EmailAddress().WithMessage("A valid email address is required.");
        }
    }
}
