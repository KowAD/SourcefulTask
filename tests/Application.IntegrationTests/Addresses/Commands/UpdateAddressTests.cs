using SourcefulTask.Application.Common.Exceptions;
using SourcefulTask.Application.Addresses.Commands.CreateAddress;
using SourcefulTask.Application.Addresses.Commands.UpdateAddress;
using SourcefulTask.Application.Employees.Commands.CreateEmployee;
using SourcefulTask.Domain.Entities;
using FluentAssertions;
using System.Threading.Tasks;
using NUnit.Framework;
using System;

namespace SourcefulTask.Application.IntegrationTests.Addresses.Commands
{
    using static Testing;

    public class UpdateAddressTests : TestBase
    {
        [Test]
        public void ShouldRequireValidAddressId()
        {
            var command = new UpdateAddressCommand
            {
                Id = 99999,
                Street = "Łąćna",
                City = "Poznań",
                PostCode = "66666"
            };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<NotFoundException>();
        }

        [Test]
        public async Task ShouldUpdateAddress()
        {
            var userId = await RunAsDefaultUserAsync();

            var employeeId = await SendAsync(new CreateEmployeeCommand
            {
                FirstName = "TestFirstName",
                LastName = "TestUpdateLastName",
                Email = "Test@example.com",
                Pesel = "12345612"
            });

            var addressId = await SendAsync(new CreateAddressCommand
            {
                EmployeeId = employeeId,
                Street = "BeforeUpdateStreet",
                City = "BeforeUpdateCity",
                PostCode = "66666"
            });

            var command = new UpdateAddressCommand
            {
                Id = addressId,
                Street = "AfterUpdateStreet",
                City = "AfterUpdateCity",
                PostCode = "1231231"
            };

            await SendAsync(command);

            var addr = await FindAsync<Address>(addressId);

            addr.Should().NotBeNull();
            addr.Street.Should().Be(command.Street);
            addr.City.Should().Be(command.City);
            addr.PostCode.Should().Be(command.PostCode);
            addr.LastModifiedBy.Should().NotBeNull();
            addr.LastModifiedBy.Should().Be(userId);
            addr.LastModified.Should().NotBeNull();
            addr.LastModified.Should().BeCloseTo(DateTime.Now, 1000);
        }
    }
}
