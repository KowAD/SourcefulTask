using FluentValidation;

namespace SourcefulTask.Application.EmployeeContracts.Queries.GetEmployeeContractsWithPagination
{
    public class GetEmployeeContractsWithPaginationQueryValidator : AbstractValidator<GetEmployeeContractsWithPaginationQuery>
    {
        public GetEmployeeContractsWithPaginationQueryValidator()
        {

            RuleFor(x => x.PageNumber)
                .GreaterThanOrEqualTo(1)
                .WithMessage("PageNumber at least greater than or equal to 1.");

            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1)
                .WithMessage("PageSize at least greater than or equal to 1.");
        }
    }
}
