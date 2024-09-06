using System.ComponentModel.DataAnnotations;

namespace EmployeeApp.Dtos
{
    public class EmployeeDTO
    {
        [Required(ErrorMessage = "Employee ID is required")]
        public string EmployeeID { get; set; }

        [Required(ErrorMessage = "Full Name is required")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Birth Date is required")]
        public string BirthDate { get; set; }
    }
}
