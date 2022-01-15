using EmployeeManagement.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Data
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int employeeId);
        Task<Employee> GetEmployeeByEmail(string email);
        Task<Employee> AddEmployee(Employee employee);
        Task<Employee> UpdateEmployee(Employee employee);
        Task<Employee> DeleteEmployee(int employeeId);
        Task<IEnumerable<Employee>> Search(string name, Gender? gender);
    }
}
