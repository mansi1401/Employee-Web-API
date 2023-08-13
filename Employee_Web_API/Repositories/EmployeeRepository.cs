using Employee_Web_API.Models;
using Employee_Web_API.Repositories.Interfaces;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace Employee_Web_API.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly string _connectionString;
        public EmployeeRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<Employee>> GetAllEmployee()
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();
                string sQuery = "SELECT * FROM Employee";
                List<Employee> AllEmployee = (await dbConnection.QueryAsync<Employee>(sQuery)).ToList();
                dbConnection.Close();
                return AllEmployee;
            }
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();
                string sQuery = "SELECT * FROM Employee WHERE Emp_Id = @Id";
                Employee AllEmployee = (await dbConnection.QueryFirstOrDefaultAsync<Employee>(sQuery, new { Id = id }));
                dbConnection.Close();
                return AllEmployee;
            }
        }

        public async Task<Employee> GetEmployeeByName(string name)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();
                string sQuery = "SELECT * FROM Employee WHERE Name = @Name";
                Employee AllEmployee = (await dbConnection.QueryFirstOrDefaultAsync<Employee>(sQuery, new { Name = name }));
                dbConnection.Close();
                return AllEmployee;
            }
        }

        public async Task<bool> AddEmployee(Employee employee)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();
                string sQuery = "INSERT INTO Employee (Name, Email, Password, Salary) VALUES(@Name, @Email, @Password, @Salary)";
                int count = await dbConnection.ExecuteAsync(sQuery, employee);
                dbConnection.Close();
                if (count > 0)
                {
                    return true;
                }
                else
                { 
                    return false; 
                }
            }
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();
                string sQuery = "DELETE FROM Employee WHERE Emp_Id = @Id";
                int count = await dbConnection.ExecuteAsync(sQuery, new { Id = id });
                dbConnection.Close();
                if (count > 0)
                {
                    return true;
                }
                return false;
            }
        }

        public async Task<bool> UpdateEmployee(Employee employee)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();
                string sQuery = "UPDATE Employee SET Name = @Name, Email = @Email, Password = @Password, Salary = @Salary WHERE Emp_Id = @Emp_Id";
                int count = await dbConnection.ExecuteAsync(sQuery, employee);
                dbConnection.Close();
                if (count > 0)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
