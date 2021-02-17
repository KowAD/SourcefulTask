using SourcefulTask.Application.Common.Exceptions;
using SourcefulTask.Application.Employees.Commands.CreateEmployee;
using SourcefulTask.Application.Employees.Commands.UpdateEmployee;
using SourcefulTask.Domain.Entities;
using FluentAssertions;
using System.Threading.Tasks;
using NUnit.Framework;
using System;

namespace SourcefulTask.Application.IntegrationTests.Employees.Commands
{
    using static Testing;

    public class UpdateEmployeeTests : TestBase
    {
        [Test]
        public void ShouldRequireValidEmployeeId()
        {
            var command = new UpdateEmployeeCommand
            {
                Id = 99999,
                FirstName = "ToUpdateFirstName",
                LastName = "ToUpdateLastName",
                Email = "test@example.com",
                Pesel = "12345612"
            };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<NotFoundException>();
        }

        [Test]
        public async Task ShouldUpdateEmployee()
        {
            var userId = await RunAsDefaultUserAsync();

            var employeeId = await SendAsync(new CreateEmployeeCommand
            {
                FirstName = "BeforeUpdateFirstName",
                LastName = "BeforeUpdateLastName",
                Email = "before@example.com",
                Pesel = "12345612"
            });

            var command = new UpdateEmployeeCommand
            {
                Id = employeeId,
                FirstName = "AfterUpdateFirstName",
                LastName = "AfterUpdateLastName",
                Email = "after@example.com",
                Pesel = "2222222"
            };

            await SendAsync(command);

            var empl = await FindAsync<Employee>(employeeId);

            empl.Should().NotBeNull();
            empl.FirstName.Should().Be(command.FirstName);
            empl.LastName.Should().Be(command.LastName);
            empl.Email.Should().Be(command.Email);
            empl.Pesel.Should().Be(command.Pesel);
            empl.LastModifiedBy.Should().NotBeNull();
            empl.LastModifiedBy.Should().Be(userId);
            empl.LastModified.Should().NotBeNull();
            empl.LastModified.Should().BeCloseTo(DateTime.Now, 1000);
        }
    }
}
