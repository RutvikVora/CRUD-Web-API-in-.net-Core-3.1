using EmployeeManagement.Entities;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class EmployeeModel
    {
        /// <summary>
        /// constructor of class
        /// </summary>
        public EmployeeModel()
        {

        }

        /// <summary>
        /// constructor for initialization
        /// </summary>
        /// <param name="emp"></param>
        public EmployeeModel(Employee emp)
        {
            //this.Id = emp.Id;
            this.EmpName = emp.EmpName;
            this.Email = emp.Email;
            this.Gender = emp.Gender;
            this.Salary = emp.Salary;
            this.Department = emp.Department;
        }

        /// <summary>
        /// mapping model properties to entity properties
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="employeeModel"></param>
        public void MappingModelToEntity(Employee employee, EmployeeModel employeeModel)
        {
            employee.EmpName = employeeModel.EmpName;
            employee.Email = employeeModel.Email;
            employee.Gender = employeeModel.Gender;
            employee.Salary = employeeModel.Salary;
            employee.Department = employeeModel.Department;
        }

        /// <summary>
        /// conversion of model to entity
        /// </summary>
        /// <param name="employeeModel"></param>
        public static implicit operator Employee(EmployeeModel employeeModel)
        {
            return new Employee
            {
                //Id = employeeModel.Id,
                EmpName = employeeModel.EmpName,
                Email = employeeModel.Email,
                Gender = employeeModel.Gender,
                Salary = employeeModel.Salary,
                Department = employeeModel.Department
            };
        }

        /// <summary>
        /// Id of employee - PK
        /// </summary>
        //public int Id { get; set; }

        /// <summary>
        /// name of employee
        /// </summary>
        public string EmpName { get; set; }

        /// <summary>
        /// email address of employee
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// gender of employee
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// salary of employee
        /// </summary>
        public int Salary { get; set; }

        /// <summary>
        /// department name in which employee works
        /// </summary>
        public string Department { get; set; }
    }
}
