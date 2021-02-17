using SourcefulTask.Application.Common.Models;
using SourcefulTask.Application.Employees.Queries.GetEmployeesWithPagination;
using SourcefulTask.Application.Employees.Queries.GetEmployee;
using SourcefulTask.Application.Employees.Commands.CreateEmployee;
using SourcefulTask.Application.Employees.Commands.UpdateEmployee;
using SourcefulTask.Application.Employees.Commands.DeleteEmployee;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SourcefulTask.WebUI.Controllers
{
    [Authorize]
    public class EmployeesController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<PaginatedList<EmployeeDto>>> GetEmployeesWithPagination([FromQuery] GetEmployeesWithPaginationQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetEmployeeDetailsDto>> Get(int id)
        {
            return await Mediator.Send(new GetEmployeeDetailsQuery { EmployeeId = id });
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateEmployeeCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateEmployeeCommand command)
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
            await Mediator.Send(new DeleteEmployeeCommand { Id = id });

            return NoContent();
        }
    }
}
