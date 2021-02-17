using SourcefulTask.Application.Common.Exceptions;
using SourcefulTask.Application.EmployeeContracts.Commands.CreateEmployeeContract;
using SourcefulTask.Application.EmployeeContracts.Commands.UpdateEmployeeContract;
using SourcefulTask.Application.Employees.Commands.CreateEmployee;
using SourcefulTask.Domain.Entities;
using FluentAssertions;
using System.Threading.Tasks;
using NUnit.Framework;
using System;

namespace SourcefulTask.Application.IntegrationTests.EmployeeContracts.Commands
{
    using static Testing;

    public class UpdateEmployeeContractTests : TestBase
    {
        [Test]
        public void ShouldRequireValidEmployeeContractId()
        {
            var command = new UpdateEmployeeContractCommand
            {
                Id = 99999,
                Number = "Number",
                ContractDate = DateTime.Now,
                ValidFrom = DateTime.Now,
                ValidTo = DateTime.Now
            };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<NotFoundException>();
        }

        [Test]
        public async Task ShouldUpdateEmployeeContract()
        {
            var userId = await RunAsDefaultUserAsync();

            var employeeId = await SendAsync(new CreateEmployeeCommand
            {
                FirstName = "TestFirstName",
                LastName = "TestUpdateLastName",
                Email = "Test@example.com",
                Pesel = "12345612"
            });

            var employeeContractId = await SendAsync(new CreateEmployeeContractCommand
            {
                EmployeeId = employeeId,
                Number = "BeforeNumber",
                ContractDate = DateTime.Now,
                ValidFrom = DateTime.Now,
                ValidTo = DateTime.Now
            });

            var command = new UpdateEmployeeContractCommand
            {
                Id = employeeContractId,
                EmployeeId = employeeId,
                Number = "AfterNumber",
                ContractDate = DateTime.Now.AddDays(1),
                ValidFrom = DateTime.Now.AddDays(-2),
                ValidTo = DateTime.Now.AddDays(30)
            };

            await SendAsync(command);

            var contr = await FindAsync<EmployeeContract>(employeeContractId);

            contr.Should().NotBeNull();
            contr.Number.Should().Be(command.Number);
            contr.ContractDate.Should().Be(command.ContractDate);
            contr.ValidFrom.Should().Be(command.ValidFrom);
            contr.ValidTo.Should().Be(command.ValidTo);
            contr.LastModifiedBy.Should().NotBeNull();
            contr.LastModifiedBy.Should().Be(userId);
            contr.LastModified.Should().NotBeNull();
            contr.LastModified.Should().BeCloseTo(DateTime.Now, 1000);
        }
    }
}
