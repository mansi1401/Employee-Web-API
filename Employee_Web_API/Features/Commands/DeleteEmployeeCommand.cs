using MediatR;

namespace Employee_Web_API.Features.Commands
{
    public class DeleteEmployeeCommand : IRequest<bool>
    {
        public int Emp_Id { get; set; }
    }
}
