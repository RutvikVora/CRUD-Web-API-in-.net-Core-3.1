using System;
using System.Collections.Generic;

namespace EmployeeManagement.Models
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string EmpName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public int Salary { get; set; }
        public string Department { get; set; }
    }
}
