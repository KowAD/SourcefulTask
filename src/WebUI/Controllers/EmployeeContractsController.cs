using SourcefulTask.Application.Common.Models;
using SourcefulTask.Application.EmployeeContracts.Queries.GetEmployeeContractsWithPagination;
using SourcefulTask.Application.EmployeeContracts.Queries.GetEmployeeContract;
using SourcefulTask.Application.EmployeeContracts.Commands.CreateEmployeeContract;
using SourcefulTask.Application.EmployeeContracts.Commands.UpdateEmployeeContract;
using SourcefulTask.Application.EmployeeContracts.Commands.DeleteEmployeeContract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SourcefulTask.WebUI.Controllers
{
    [Authorize]
    public class EmployeeContractsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<PaginatedList<EmployeeContractDto>>> GetEmployeeContractsWithPagination([FromQuery] GetEmployeeContractsWithPaginationQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateEmployeeContractCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateEmployeeContractCommand command)
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
            await Mediator.Send(new DeleteEmployeeContractCommand { Id = id });

            return NoContent();
        }
    }
}
