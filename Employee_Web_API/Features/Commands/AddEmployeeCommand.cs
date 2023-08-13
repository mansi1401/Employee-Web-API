using Employee_Web_API.Models;
using MediatR;

namespace Employee_Web_API.Features.Commands
{
    public class AddEmployeeCommand : IRequest<bool>
    {
        public AddEmployeeCommand(string name, string email, string password, string salary)
        {
            Name = name;
            Email = email;
            Password = password;
            Salary = salary;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salary { get; set; }
    }
}
