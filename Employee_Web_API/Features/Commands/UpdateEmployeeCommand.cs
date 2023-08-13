using MediatR;

namespace Employee_Web_API.Features.Commands
{
    public class UpdateEmployeeCommand : IRequest<bool>
    {
        public UpdateEmployeeCommand(int id, string name, string email, string password, string salary)
        {
            Emp_Id = id;
            Name = name;
            Email = email;
            Password = password;
            Salary = salary;
        }

        public int Emp_Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salary { get; set; }
    }
}
