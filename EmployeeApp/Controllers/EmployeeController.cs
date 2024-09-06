using EmployeeApp.Dtos;
using EmployeeApp.Models;
using EmployeeApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: api/employee
        [HttpGet]
        public ActionResult<List<EmployeeDTO>> Get()
        {
            var employees = _employeeService.GetEmployees();
            return Ok(employees);
        }

        // GET: api/employee/{id}
        [HttpGet("{id}")]
        public ActionResult<EmployeeDTO> Get(string id)
        {
            var employee = _employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return employee;
        }

        // POST: api/employee
        [HttpPost]
        public IActionResult CreateEmployee([FromBody] EmployeeDTO employeeDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _employeeService.AddEmployee(employeeDTO);
                    return Ok("Employee added successfully");
                }
                catch (FormatException)
                {
                    return BadRequest("Invalid date format. Please use dd-MM-yyyy.");
                }
            }

            return BadRequest(ModelState);
        }

        // DELETE: api/employee/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var employee = _employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            _employeeService.DeleteEmployee(id);
            return Ok();
        }
    }
}
