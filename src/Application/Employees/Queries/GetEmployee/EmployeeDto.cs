using SourcefulTask.Application.Common.Mappings;
using SourcefulTask.Domain.Entities;

namespace SourcefulTask.Application.Employees.Queries.GetEmployee
{
    public class EmployeeDto : IMapFrom<Employee>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Pesel { get; set; }

    }
}
