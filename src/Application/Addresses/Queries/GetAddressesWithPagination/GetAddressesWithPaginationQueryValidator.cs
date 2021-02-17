using FluentValidation;

namespace SourcefulTask.Application.Addresses.Queries.GetAddressesWithPagination
{
    public class GetAddressesWithPaginationQueryValidator : AbstractValidator<GetAddressesWithPaginationQuery>
    {
        public GetAddressesWithPaginationQueryValidator()
        {

            RuleFor(x => x.EmployeeId)
                .NotNull()
                .NotEmpty().WithMessage("EmployeeId is required.");

            RuleFor(x => x.PageNumber)
                .GreaterThanOrEqualTo(1)
                .WithMessage("PageNumber at least greater than or equal to 1.");

            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1)
                .WithMessage("PageSize at least greater than or equal to 1.");
        }
    }
}
