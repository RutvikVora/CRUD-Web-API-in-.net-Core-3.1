namespace EmployeeManagement.Repository
{
    using EmployeeManagement.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using EmployeeManagement.Repository.Interfaces;

    public class EmployeeRepository: IEmployeeRepository
    {
        private EmployeeManagementContext _context;
        public EmployeeRepository(EmployeeManagementContext context)
        {
            _context = context;
        }

        /// <summary>
        /// get list of all employees
        /// </summary>
        /// <returns></returns>
        public List<Employee> GetEmployeesList()
        {
            return _context.Set<Employee>().ToList();
        }

        /// <summary>
        /// get employee details by employee id
        /// </summary>
        /// <param name="empId"></param>
        /// <returns></returns>
        public Employee GetEmployeeDetailsById(int empId)
        {
            return _context.Find<Employee>(empId);
        }

        /// <summary>
        ///  add edit employee
        /// </summary>
        /// <param name="employeeModel"></param>
        /// <returns></returns>
        public Employee UpsertEmployee(EmployeeModel employeeModel)
        {
            try
            {
                Employee empDb = GetEmployeeDetailsById(employeeModel.Id);
                if (empDb != null)
                {
                        empDb.EmpName = employeeModel.EmpName;
                        empDb.Email = employeeModel.Email;
                        empDb.Gender = employeeModel.Gender;
                        empDb.Salary = employeeModel.Salary;
                        empDb.Department = employeeModel.Department;
                        _context.Update(empDb);
                        _context.SaveChanges();
                        return empDb;
                }
                else
                {
                    var email = _context.Employee.Where(x => x.Email.Equals(employeeModel.Email)).FirstOrDefault();


                    if (email == null)
                    {
                        Employee emptemp = new Employee();
                        emptemp.Id = employeeModel.Id;
                        emptemp.EmpName = employeeModel.EmpName;
                        emptemp.Email = employeeModel.Email;
                        emptemp.Gender = employeeModel.Gender;
                        emptemp.Salary = employeeModel.Salary;
                        emptemp.Department = employeeModel.Department;
                        _context.Add<Employee>(emptemp);
                        _context.SaveChanges();
                        return emptemp;
                    }
                    else
                    {
                        return null;
                    }
                }
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// delete employees
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public string DeleteEmployee(int employeeId)
        {
            Employee employee = _context.Employee.Find(employeeId);
            if (employee != null)
            {
                _context.Employee.Remove(employee);
                _context.SaveChanges();
                return ("Deleted");
            }
            else
            {
                return ("Employee not found");
            }
        }
        
    }
}
