using System;
using SourcefulTask.Domain.Common;

namespace SourcefulTask.Domain.Entities
{
    public class EmployeeContract : AuditableEntity
    {
        public int Id { get; set; }

        public Employee List { get; set; }

        public int EmployeeId { get; set; }

        public string Number { get; set; }

        public DateTime ContractDate { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime ValidTo { get; set; }

    }
}
