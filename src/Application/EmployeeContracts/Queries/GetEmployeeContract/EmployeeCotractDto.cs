using System;
using SourcefulTask.Application.Common.Mappings;
using SourcefulTask.Domain.Entities;

namespace SourcefulTask.Application.EmployeeContracts.Queries.GetEmployeeContract
{
    public class EmployeeContractDto : IMapFrom<EmployeeContract>
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public string Number { get; set; }

        public DateTime ContractDate { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime ValidTo { get; set; }
    }
}
