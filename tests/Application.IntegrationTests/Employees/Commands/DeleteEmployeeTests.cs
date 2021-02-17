using SourcefulTask.Application.Common.Exceptions;
using SourcefulTask.Application.Employees.Commands.CreateEmployee;
using SourcefulTask.Application.Employees.Commands.DeleteEmployee;
using SourcefulTask.Domain.Entities;
using FluentAssertions;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SourcefulTask.Application.IntegrationTests.Employees.Commands
{
    using static Testing;

    public class DeleteEmployeeTests : TestBase
    {
        [Test]
        public void ShouldRequireValidEmployeeId()
        {
            var command = new DeleteEmployeeCommand { Id = 99999 };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<NotFoundException>();
        }

        [Test]
        public async Task ShouldDeleteEmployee()
        {
            var command = new CreateEmployeeCommand
            {
                FirstName = "ToDeleteFirstName",
                LastName = "ToDeleteLastName",
                Email = "test@example.com",
                Pesel = "12345612"
            };

            var employeeId = await SendAsync(command);

            await SendAsync(new DeleteEmployeeCommand
            {
                Id = employeeId
            });

            var list = await FindAsync<Employee>(employeeId);

            list.Should().BeNull();
        }
    }
}