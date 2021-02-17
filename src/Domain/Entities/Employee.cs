using SourcefulTask.Domain.Common;
using System.Collections.Generic;

namespace SourcefulTask.Domain.Entities
{
    public class Employee : AuditableEntity
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Pesel { get; set; }

        public ICollection<Address> Addresses { get; private set; } = new HashSet<Address>();

        public ICollection<EmployeeContract> Contracts { get; private set; } = new HashSet<EmployeeContract>();
    }
}
