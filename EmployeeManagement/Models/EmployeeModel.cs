using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class EmployeeModel
    {
        public EmployeeModel()
        {

        }
        public EmployeeModel(Employee emp)
        {
            this.Id = emp.Id;
            this.EmpName = emp.EmpName;
            this.Email = emp.Email;
            this.Gender = emp.Gender;
            this.Salary = emp.Salary;
            this.Department = emp.Department;
        }
        [Required]
        [RegularExpression(@"[0-9]")]
        public int Id { get; set; }

        [Required]
        public string EmpName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public int Salary { get; set; }

        [Required]
        public string Department { get; set; }
    }
}
