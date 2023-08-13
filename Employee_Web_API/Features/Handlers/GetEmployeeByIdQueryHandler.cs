using Employee_Web_API.Features.Queries;
using Employee_Web_API.Models;
using Employee_Web_API.Repositories.Interfaces;
using MediatR;

namespace Employee_Web_API.Features.Handlers
{
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, Employee>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetEmployeeByIdQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Employee> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            return await _employeeRepository.GetEmployeeById(request.Emp_Id);
        }
    }
}
