using SourcefulTask.Application.Common.Exceptions;
using SourcefulTask.Application.EmployeeContracts.Commands.CreateEmployeeContract;
using SourcefulTask.Application.Employees.Commands.CreateEmployee;
using SourcefulTask.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace SourcefulTask.Application.IntegrationTests.EmployeeContracts.Commands
{
    using static Testing;

    public class CreateEmployeeContractTests : TestBase
    {
        [Test]
        public void ShouldRequireFields()
        {
            var command = new CreateEmployeeContractCommand();
            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<ValidationException>();
        }

        [Test]
        public async Task ShouldCreateCreateEmployeeContract()
        {
            var userId = await RunAsDefaultUserAsync();

            var employeeId = await SendAsync(new CreateEmployeeCommand
            {
                FirstName = "TestFirstName",
                LastName = "TestUpdateLastName",
                Email = "Test@example.com",
                Pesel = "12345612"
            });

            var command = new CreateEmployeeContractCommand
            {
                EmployeeId = employeeId,
                Number = "NCC312312",
                ContractDate = DateTime.Now,
                ValidFrom = DateTime.Now,
                ValidTo = DateTime.Now
            };

            var employeeContractId = await SendAsync(command);
            var contr = await FindAsync<EmployeeContract>(employeeContractId);

            contr.Should().NotBeNull();
            contr.EmployeeId.Should().Be(command.EmployeeId);
            contr.Number.Should().Be(command.Number);
            contr.ContractDate.Should().Be(command.ContractDate);
            contr.ValidFrom.Should().Be(command.ValidFrom);
            contr.ValidTo.Should().Be(command.ValidTo);
            contr.CreatedBy.Should().Be(userId);
            contr.Created.Should().BeCloseTo(DateTime.Now, 10000);
            contr.LastModifiedBy.Should().BeNull();
            contr.LastModified.Should().BeNull();
        }
    }
}
