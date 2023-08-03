using MediatR;
using Microsoft.AspNetCore.Mvc;
using RedarborTechnicalTest.Core.Dtos;
using RedarborTechnicalTest.Core.Services.Commands;
using RedarborTechnicalTest.Core.Services.Querys;
using static RedarborTechnicalTest.Api.Contracts.ApiRoutes;

namespace RedarborTechnicalTest.Api.Controllers
{
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EmployeeController(IMediator mediator) 
        { 
            _mediator = mediator;
        }

        [HttpGet]
        [Route(EmployeeRoutes.GetEmployee)]
        public async Task<IActionResult> GetEmployees()
        {
            return Ok(await _mediator.Send(new GetEmployeeQuery()));
        }
        [HttpGet]
        [Route(EmployeeRoutes.GetEmployeeById)]
        public async Task<IActionResult> GetEmployee(int id)
        {
            return Ok(await _mediator.Send(new GetEmployeeByIdQuery(id)));
        }
        [HttpPost]
        [Route(EmployeeRoutes.AddEmployee)] 
        public async Task<IActionResult> AddEmployee([FromBody]EmployeeDto employee)
        {
            await _mediator.Send(new CreateEmployeeCommand(employee));
            return Ok(employee);
        }
        [HttpPut]
        [Route(EmployeeRoutes.UpdateEmployee)]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] EmployeeDto employee)
        {
            return Ok(await _mediator.Send(new UpdateEmployeeCommand(id,employee)));
        }
        [HttpDelete]
        [Route(EmployeeRoutes.DeleteEmployee)]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            return Ok(await _mediator.Send(new DeleteEmployeeCommand(id)));
        }

    }
}
