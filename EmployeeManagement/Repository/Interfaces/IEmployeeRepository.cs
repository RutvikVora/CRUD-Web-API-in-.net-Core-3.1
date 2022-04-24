namespace EmployeeManagement.Repository.Interfaces
{
    using EmployeeManagement.Entities;
    using EmployeeManagement.Models;
    using System.Linq;

    public interface IEmployeeRepository
    {
        /// <summary>
        /// get list of all employees
        /// </summary>
        /// <returns>list of all employees</returns>
        public IQueryable<Employee> GetEmployeesList();

        /// <summary>
        /// get employee details by employee id
        /// </summary>
        /// <param name="empId"></param>
        /// <returns>employee of particular Id</returns>
        Employee GetEmployeeDetailsById(int? empId);

        /// <summary>
        ///  add edit employee
        /// </summary>
        /// <param name="employeeModel"></param>
        /// <returns>employee entity</returns>
        Employee UpsertEmployee(EmployeeModel employeeModel);


        /// <summary>
        /// delete employees
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        void DeleteEmployee(int employeeId);

    }
}
