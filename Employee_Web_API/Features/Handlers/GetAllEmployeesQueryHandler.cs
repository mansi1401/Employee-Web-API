using Employee_Web_API.Features.Queries;
using Employee_Web_API.Models;
using Employee_Web_API.Repositories.Interfaces;
using MediatR;

namespace Employee_Web_API.Features.Handlers
{
    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, List<Employee>>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetAllEmployeesQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<Employee>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            return await _employeeRepository.GetAllEmployee();
        }
    }
}
