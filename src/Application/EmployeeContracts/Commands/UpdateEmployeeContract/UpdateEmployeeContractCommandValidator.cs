using FluentValidation;

namespace SourcefulTask.Application.EmployeeContracts.Commands.UpdateEmployeeContract
{
    public class UpdateEmployeeContractCommandValidator : AbstractValidator<UpdateEmployeeContractCommand>
    {
        public UpdateEmployeeContractCommandValidator()
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
