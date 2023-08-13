using Employee_Web_API.Features.Commands;
using Employee_Web_API.Models;
using Employee_Web_API.Repositories.Interfaces;
using MediatR;

namespace Employee_Web_API.Features.Handlers
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, bool>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<bool> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            Employee employee = await _employeeRepository.GetEmployeeById(request.Emp_Id);
            if (employee == null) return default;
             
            employee.Name = request.Name;
            employee.Email = request.Email;
            employee.Password = request.Password;
            employee.Salary = request.Salary;
            return await _employeeRepository.UpdateEmployee(employee);
        }
    }
}
