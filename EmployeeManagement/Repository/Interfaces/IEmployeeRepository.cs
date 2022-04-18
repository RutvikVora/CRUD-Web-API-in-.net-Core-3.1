using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using System.Collections.Generic;

namespace EmployeeManagement.Repository.Interfaces
{
    public interface IEmployeeRepository
    {
        /// <summary>
        /// get list of all employees
        /// </summary>
        /// <returns></returns>
        List<Employee> GetEmployeesList();

        /// <summary>
        /// get employee details by employee id
        /// </summary>
        /// <param name="empId"></param>
        /// <returns></returns>
        Employee GetEmployeeDetailsById(int empId);

        /// <summary>
        ///  add edit employee
        /// </summary>
        /// <param name="employeeModel"></param>
        /// <returns></returns>
        Employee UpsertEmployee(EmployeeModel employeeModel);


        /// <summary>
        /// delete employees
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        string DeleteEmployee(int employeeId);
    }
}
