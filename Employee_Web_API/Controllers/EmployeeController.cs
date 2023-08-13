using Employee_Web_API.Features.Commands;
using Employee_Web_API.Features.Queries;
using Employee_Web_API.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //Get All Employee
        [Route("Get")]
        [HttpGet]
        public async Task<IActionResult> GetAllEmployee()
        {
            List<Employee> AllEmployee = (await _mediator.Send(new GetAllEmployeesQuery()));
            return Ok(AllEmployee);
        }

        //Get Employee By Id
        [Route("Details/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            Employee AllEmployee = await _mediator.Send(new GetEmployeeByIdQuery() { Emp_Id = id });
            return Ok(AllEmployee);
        }

        //Get Employee By Name
        [Route("Search/{name}")]
        [HttpGet]
        public async Task<IActionResult> GetEmployeeByName(string name)
        {
            Employee AllEmployee = await _mediator.Send(new GetEmployeesByNameQuery() { Name = name });
            return Ok(AllEmployee);
        }

        //Add Employee
        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee employee)
        {
            bool AddEmployeeStatus = await _mediator.Send(new AddEmployeeCommand(employee.Name, employee.Email, employee.Password, employee.Salary));
            return Ok(AddEmployeeStatus);
        }

        //Delete Employee
        [Route("Delete/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            bool DeleteEmployeeStatus = await _mediator.Send(new DeleteEmployeeCommand() { Emp_Id = id });
            return Ok(DeleteEmployeeStatus);
        }

        //Edit Employee
        [Route("Edit/{id:int}")]
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(int id, Employee employee)
        {
            bool UpdateEmployeeStatus = await _mediator.Send(new UpdateEmployeeCommand(id, employee.Name, employee.Email, employee.Password, employee.Salary));
            return Ok(UpdateEmployeeStatus);
        }
    }
}
