using SourcefulTask.Domain.Common;

namespace SourcefulTask.Domain.Entities
{
    public class Address : AuditableEntity
    {
        public int Id { get; set; }

        public Employee List { get; set; }

        public int EmployeeId { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string PostCode { get; set; }

    }
}
