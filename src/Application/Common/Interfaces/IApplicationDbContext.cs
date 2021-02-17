using SourcefulTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace SourcefulTask.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<TodoList> TodoLists { get; set; }

        DbSet<TodoItem> TodoItems { get; set; }

        DbSet<Employee> Employees { get; set; }

        DbSet<Address> Addresses { get; set; }

        DbSet<EmployeeContract> EmployeeContracts { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
