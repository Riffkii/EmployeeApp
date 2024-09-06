using EmployeeApp.Dtos;
using EmployeeApp.Models;

namespace EmployeeApp.Services
{
    public interface IEmployeeService
    {
        List<EmployeeDTO> GetEmployees();
        EmployeeDTO GetEmployeeById(string id);
        void AddEmployee(EmployeeDTO employee);
        void DeleteEmployee(string id);
    }
}
