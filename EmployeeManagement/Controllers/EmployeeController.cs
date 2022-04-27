namespace EmployeeManagement.Controllers
{
    using EmployeeManagement.Entities;
    using EmployeeManagement.Models;
    using EmployeeManagement.Repository.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;

    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="employeeRepository"></param>
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        /// <summary>
        /// get all employess
        /// </summary>
        /// <returns>List of all Employees</returns>
        [HttpGet]
        public ActionResult<List<EmployeeModel>> GetAllEmployees()
        {
            return Ok(this.employeeRepository.GetEmployeesList());
        }

        /// <summary>
        /// get employee details by id
        /// </summary>
        /// <param name="empId"></param>
        /// <returns>employee details of particular Id</returns>
        [HttpGet("{empId}")]
        public ActionResult<List<EmployeeModel>> GetEmployeeById(int empId)
        {
            return Ok(this.employeeRepository.GetEmployeeDetailsById(empId));
        }

        /// <summary>
        /// add or edit employee
        /// </summary>
        /// <param name="employeeModel"></param>
        /// <returns>Model of employee</returns>
        [HttpPost]
        public ActionResult<EmployeeModel> UpsertEmployee(EmployeeModel employeeModel)
        {
            try
            {
                Employee result = this.employeeRepository.UpsertEmployee(employeeModel);
                if (result != null)
                {
                    EmployeeModel empModel = new EmployeeModel(result);
                    return Ok(empModel);
                }
                else
                {
                    return StatusCode(StatusCodes.Status409Conflict);
                }
                
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// delete employee
        /// </summary>
        /// <param name="empId"></param>
        /// <returns>success message of deleted</returns>
        [HttpDelete("{empId}")]
        public ActionResult<string> DeleteEmployee(int empId)
        {
            try
            {
                Employee employee = this.employeeRepository.GetEmployeeDetailsById(empId);

                if(employee == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }
                this.employeeRepository.DeleteEmployee(empId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                        ex.Message);
            }
        }
    }
}
