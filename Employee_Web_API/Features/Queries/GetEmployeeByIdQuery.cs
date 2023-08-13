using Employee_Web_API.Models;
using MediatR;

namespace Employee_Web_API.Features.Queries
{
    public class GetEmployeeByIdQuery : IRequest<Employee>
    {
        public int Emp_Id { get; set; }
    }
}
