using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SourcefulTask.Application.Addresses.Queries.GetAddress;
using SourcefulTask.Application.Common.Models;
//using SourcefulTask.Application.TodoItems.Commands.CreateTodoItem;
//using SourcefulTask.Application.TodoItems.Commands.DeleteTodoItem;
//using SourcefulTask.Application.TodoItems.Commands.UpdateTodoItem;
//using SourcefulTask.Application.TodoItems.Commands.UpdateTodoItemDetail;

using SourcefulTask.Application.Employees.Queries.GetEmployeesWithPagination;
using SourcefulTask.Application.Employees.Queries.GetEmployee;
using SourcefulTask.Application.Addresses.Queries.GetAddressesWithPagination;
using SourcefulTask.Application.Addresses.Commands.CreateAddress;
using SourcefulTask.Application.Addresses.Commands.UpdateAddress;
using SourcefulTask.Application.Addresses.Commands.DeleteAddress;
using SourcefulTask.Application.Employees.Commands.CreateEmployee;
using SourcefulTask.Application.Employees.Commands.UpdateEmployee;
using SourcefulTask.Application.Employees.Commands.DeleteEmployee;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SourcefulTask.WebUI.Controllers
{
    //[Authorize]
    public class AddressesController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<PaginatedList<AddressDto>>> GetEmployeesWithPagination([FromQuery] GetAddressesWithPaginationQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateAddressCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateAddressCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteAddressCommand { Id = id });

            return NoContent();
        }
    }
}
