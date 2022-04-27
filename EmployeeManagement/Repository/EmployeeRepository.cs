namespace EmployeeManagement.Repository
{
    using EmployeeManagement.Models;
    using System;
    using System.Linq;
    using EmployeeManagement.Repository.Interfaces;
    using EmployeeManagement.Entities;
    using System.Security.Claims;
    using Microsoft.AspNetCore.Mvc;
    using EmployeeManagement.Controllers;

    public class EmployeeRepository: RepositoryBase<Employee>, IEmployeeRepository
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="employeeManagementContext"></param>
        public EmployeeRepository(EmployeeManagementContext employeeManagementContext) : base(employeeManagementContext)
        {
        }

        /// <summary>
        /// get list of all employees
        /// </summary>
        /// <returns>list of all employees</returns>
        public IQueryable<Employee> GetEmployeesList()
        {
            return this.Find();
        }

        /// <summary>
        /// get employee details by employee id
        /// </summary>
        /// <param name="empId"></param>
        /// <returns>employee of particular Id</returns>
        public Employee GetEmployeeDetailsById(int? empId)
        {
            return this.Find(x => x.Id == empId).FirstOrDefault();
        }

        /// <summary>
        ///  add edit employee
        /// </summary>
        /// <param name="employeeModel"></param>
        /// <returns>employee entity</returns>
        public Employee UpsertEmployee(EmployeeModel employeeModel)
        {
            try
            {
                Employee empDb = GetEmployeeDetailsById(employeeModel.Id);
                if (empDb != null)
                {
                    if (!IsEmailExit(employeeModel.Email, employeeModel.Id))
                    {
                        employeeModel.MappingModelToEntity(empDb,employeeModel);
                        this.UpdateEntity(empDb);
                        this.Save();
                        return empDb;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                { 
                    if (!IsEmailExit(employeeModel.Email))
                    {
                        Employee employee = employeeModel;
                        this.CreateEntity(employee);
                        this.Save();
                        return employee;
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
        public void DeleteEmployee(int employeeId)
        {
            Employee employee = this.Find(x => x.Id == employeeId).FirstOrDefault();
            this.DeleteEntity(employee);
            this.Save();
        }


        /// <summary>
        /// check that email exist or not
        /// </summary>
        /// <param name="email"></param>
        /// <returns>boolean value</returns>
        public bool IsEmailExit(string email, int? id = -1)
        {
            return this.Find(e => e.Email == email && e.Id != id).Any();
        }
    }
}
