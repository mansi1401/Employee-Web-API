using Employee_Web_API.Models;
using MediatR;

namespace Employee_Web_API.Features.Queries
{
    public class GetAllEmployeesQuery : IRequest<List<Employee>>
    {
    }
}
