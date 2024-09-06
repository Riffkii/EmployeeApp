using System.Globalization;
using EmployeeApp.Dtos;
using EmployeeApp.Models;

namespace EmployeeApp.Services
{
    public class EmployeeService : IEmployeeService
    {
        private List<Employee> _employees;

        public EmployeeService()
        {
            // Initialize with some hardcoded data
            _employees = new List<Employee>
            {
                new Employee { EmployeeID = "1001", FullName = "Adit", BirthDate = new DateTime(1954, 8, 17) },
                new Employee { EmployeeID = "1002", FullName = "Anton", BirthDate = new DateTime(1954, 8, 18) },
                new Employee { EmployeeID = "1003", FullName = "Amir", BirthDate = new DateTime(1954, 8, 19) }
            };
        }

        // Mengambil semua employees sebagai DTO
        public List<EmployeeDTO> GetEmployees()
        {
            return _employees.Select(e => new EmployeeDTO
            {
                EmployeeID = e.EmployeeID,
                FullName = e.FullName,
                BirthDate = ConvertDateToString(e.BirthDate)
            }).ToList();
        }

        // Mengambil employee berdasarkan ID sebagai DTO
        public EmployeeDTO GetEmployeeById(string id)
        {
            var employee = _employees.FirstOrDefault(e => e.EmployeeID == id);
            if (employee == null)
            {
                return null;
            }

            return new EmployeeDTO
            {
                EmployeeID = employee.EmployeeID,
                FullName = employee.FullName,
                BirthDate = ConvertDateToString(employee.BirthDate)
            };
        }

        // Menambahkan employee dari DTO ke model
        public void AddEmployee(EmployeeDTO dto)
        {
            var employee = new Employee
            {
                EmployeeID = dto.EmployeeID,
                FullName = dto.FullName,
                BirthDate = ConvertStringToDate(dto.BirthDate)
            };

            _employees.Add(employee);
        }

        public void DeleteEmployee(string id)
        {
            var employee = _employees.FirstOrDefault(e => e.EmployeeID == id);
            if (employee != null)
            {
                _employees.Remove(employee);
            }
        }

        // Konversi string "dd-MM-yyyy" ke DateTime
        private DateTime ConvertStringToDate(string dateString)
        {
            return DateTime.ParseExact(dateString, "dd-MM-yyyy", CultureInfo.InvariantCulture);
        }

        // Konversi DateTime ke string "dd-MM-yyyy"
        private string ConvertDateToString(DateTime date)
        {
            return date.ToString("dd-MM-yyyy");
        }
    }
}
