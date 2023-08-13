using Employee_Web_API.Features.Commands;
using Employee_Web_API.Models;
using Employee_Web_API.Repositories.Interfaces;
using MediatR;

namespace Employee_Web_API.Features.Handlers
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, bool>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            Employee employee = await _employeeRepository.GetEmployeeById(request.Emp_Id);
            if (employee == null)
            {
                return default;
            }

            return await _employeeRepository.DeleteEmployee(request.Emp_Id);
        }
    }
}
