using SourcefulTask.Application.Common.Exceptions;
using SourcefulTask.Application.Employees.Commands.CreateEmployee;
using SourcefulTask.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace SourcefulTask.Application.IntegrationTests.Employees.Commands
{
    using static Testing;

    public class CreateEmployeeTests : TestBase
    {
        [Test]
        public void ShouldRequireFields()
        {
            var command = new CreateEmployeeCommand();
            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<ValidationException>();
        }

        [Test]
        public async Task ShouldCreateCreateEmployee()
        {
            var userId = await RunAsDefaultUserAsync();

            var command = new CreateEmployeeCommand
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                Email = "test@example.com",
                Pesel = "12345612"
            };

            var employeeId = await SendAsync(command);
                        var empl = await FindAsync<Employee>(employeeId);

            empl.Should().NotBeNull();
            empl.FirstName.Should().Be(command.FirstName);
            empl.LastName.Should().Be(command.LastName);
            empl.Email.Should().Be(command.Email);
            empl.Pesel.Should().Be(command.Pesel);
            empl.CreatedBy.Should().Be(userId);
            empl.Created.Should().BeCloseTo(DateTime.Now, 10000);
            empl.LastModifiedBy.Should().BeNull();
            empl.LastModified.Should().BeNull();
        }
    }
}
