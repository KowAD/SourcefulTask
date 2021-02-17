using SourcefulTask.Application.Common.Mappings;
using SourcefulTask.Domain.Entities;
using SourcefulTask.Application.Addresses.Queries.GetAddress;
using SourcefulTask.Application.EmployeeContracts.Queries.GetEmployeeContract;
using System.Collections.Generic;


namespace SourcefulTask.Application.Employees.Queries.GetEmployee
{
    public class GetEmployeeDetailsDto : IMapFrom<Employee>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Pesel { get; set; }

        public virtual List<AddressDto> Addresses { get; set; }

        public virtual IList<EmployeeContractDto> Contracts { get; set; }

    }
}
