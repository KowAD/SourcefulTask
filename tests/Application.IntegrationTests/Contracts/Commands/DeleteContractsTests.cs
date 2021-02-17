using SourcefulTask.Application.Common.Exceptions;
using SourcefulTask.Application.EmployeeContracts.Commands.CreateEmployeeContract;
using SourcefulTask.Application.EmployeeContracts.Commands.DeleteEmployeeContract;
using SourcefulTask.Application.Employees.Commands.CreateEmployee;
using SourcefulTask.Domain.Entities;
using FluentAssertions;
using System.Threading.Tasks;
using NUnit.Framework;
using System;

namespace SourcefulTask.Application.IntegrationTests.EmployeeContracts.Commands
{
    using static Testing;

    public class DeleteEmployeeContractTests : TestBase
    {
        [Test]
        public void ShouldRequireValidEmployeeContractId()
        {
            var command = new DeleteEmployeeContractCommand { Id = 99999 };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<NotFoundException>();
        }

        [Test]
        public async Task ShouldDeleteEmployeeContract()
        {
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
                Number = "NCC312312",
                ContractDate = DateTime.Now,
                ValidFrom = DateTime.Now,
                ValidTo = DateTime.Now
            });


            await SendAsync(new DeleteEmployeeContractCommand
            {
                Id = employeeContractId
            });

            var list = await FindAsync<EmployeeContract>(employeeContractId);

            list.Should().BeNull();
        }
    }
}