﻿namespace EmployeeManagement.Controllers
{
    using EmployeeManagement.Models;
    using EmployeeManagement.Repository.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IEmployeeRepository employeeRepository;
        public EmployeeController(IEmployeeRepository rep)
        {
            employeeRepository = rep;
        }

        /// <summary>
        /// get all employess
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<EmployeeModel>> GetAllEmployees()
        {
            try
            {
                return Ok(employeeRepository.GetEmployeesList());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// get employee details by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<List<EmployeeModel>> GetEmployeesById(int id)
        {
            try
            {
                return Ok(employeeRepository.GetEmployeeDetailsById(id));

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// save employee
        /// </summary>
        /// <param name="employeeModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<EmployeeModel> UpsertEmployees(EmployeeModel employeeModel)
        {
            try
            {
                var result = employeeRepository.UpsertEmployee(employeeModel);
                if (result != null)
                {
                    EmployeeModel empModel = new EmployeeModel(employeeRepository.UpsertEmployee(employeeModel));
                    return Ok(empModel);
                }
                else
                {
                    return Ok("Email already exist !!!");
                }
                
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// delete employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult<string> DeleteEmployee(int id)
        {
            try
            {
                return Ok(employeeRepository.DeleteEmployee(id));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
