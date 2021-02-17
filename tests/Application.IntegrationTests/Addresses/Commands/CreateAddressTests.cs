using SourcefulTask.Application.Common.Exceptions;
using SourcefulTask.Application.Addresses.Commands.CreateAddress;
using SourcefulTask.Application.Employees.Commands.CreateEmployee;
using SourcefulTask.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace SourcefulTask.Application.IntegrationTests.Addresses.Commands
{
    using static Testing;

    public class CreateAddressTests : TestBase
    {
        [Test]
        public void ShouldRequireFields()
        {
            var command = new CreateAddressCommand();
            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<ValidationException>();
        }

        [Test]
        public async Task ShouldCreateCreateAddress()
        {
            var userId = await RunAsDefaultUserAsync();

            var employeeId = await SendAsync(new CreateEmployeeCommand
            {
                FirstName = "TestFirstName",
                LastName = "TestUpdateLastName",
                Email = "Test@example.com",
                Pesel = "12345612"
            });

            var command = new CreateAddressCommand
            {
                EmployeeId = employeeId,
                Street = "Łąćna",
                City = "Poznań",
                PostCode = "66666"
            };

            var addressId = await SendAsync(command);
            var addr = await FindAsync<Address>(addressId);

            addr.Should().NotBeNull();
            addr.EmployeeId.Should().Be(command.EmployeeId);
            addr.Street.Should().Be(command.Street);
            addr.City.Should().Be(command.City);
            addr.PostCode.Should().Be(command.PostCode);
            addr.CreatedBy.Should().Be(userId);
            addr.Created.Should().BeCloseTo(DateTime.Now, 10000);
            addr.LastModifiedBy.Should().BeNull();
            addr.LastModified.Should().BeNull();
        }
    }
}
