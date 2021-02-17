using SourcefulTask.Application.Common.Exceptions;
using SourcefulTask.Application.Addresses.Commands.CreateAddress;
using SourcefulTask.Application.Addresses.Commands.DeleteAddress;
using SourcefulTask.Application.Employees.Commands.CreateEmployee;
using SourcefulTask.Domain.Entities;
using FluentAssertions;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SourcefulTask.Application.IntegrationTests.Addresses.Commands
{
    using static Testing;

    public class DeleteAddressTests : TestBase
    {
        [Test]
        public void ShouldRequireValidAddressId()
        {
            var command = new DeleteAddressCommand { Id = 99999 };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<NotFoundException>();
        }

        [Test]
        public async Task ShouldDeleteAddress()
        {
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
                Street = "ToDelete",
                City = "Poznań",
                PostCode = "77777"
            });


            await SendAsync(new DeleteAddressCommand
            {
                Id = addressId
            });

            var list = await FindAsync<Address>(addressId);

            list.Should().BeNull();
        }
    }
}