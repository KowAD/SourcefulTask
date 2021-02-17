using FluentValidation;

namespace SourcefulTask.Application.EmployeeContracts.Commands.CreateEmployeeContract
{
    public class CreateEmployeeContractCommandValidator : AbstractValidator<CreateEmployeeContractCommand>
    {
        public CreateEmployeeContractCommandValidator()
        {
            RuleFor(v => v.Number)
                .MaximumLength(20)
                .NotEmpty();

            RuleFor(v => v.ValidFrom)
                .NotEmpty();

            RuleFor(v => v.ValidTo)
                .NotEmpty();
        }
    }
}
