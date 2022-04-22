namespace EmployeeManagement.Controllers
{
    using EmployeeManagement.Entities;
    using EmployeeManagement.Models;
    using EmployeeManagement.Repository.Interfaces;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        readonly private ITaskRepository taskRepository;
        readonly private IEmployeeRepository empRepository;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="taskRepository"></param>
        /// <param name="employeeRepository"></param>
        public TaskController(ITaskRepository taskRepository, IEmployeeRepository employeeRepository)
        {
            this.taskRepository = taskRepository;
            this.empRepository = employeeRepository;
        }

        /// <summary>
        /// get all tasks
        /// </summary>
        /// <returns>list of all tasks</returns>
        [HttpGet]
        public ActionResult<List<TaskModel>> GetAllTasks()
        {
            return Ok(this.taskRepository.GetTasksList());
        }

        /// <summary>
        /// get task details by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>task of particular taskId</returns>
        [HttpGet("{id}")]
        public ActionResult<List<TaskModel>> GetTaskById(int id)
        {
           return Ok(this.taskRepository.GetTaskById(id));
           
        }

        /// <summary>
        /// save task
        /// </summary>
        /// <param name="taskModel"></param>
        /// <returns>TaskModel</returns>
        [HttpPost]
        public ActionResult<TaskModel> UpsertTask(TaskModel taskModel)
        {
            try
            {
                TaskModel task = new TaskModel(this.taskRepository.UpsertTask(taskModel));
                return Ok(task);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); 
            }
        }

        /// <summary>
        /// delete task
        /// </summary>
        /// <param name="id"></param>
        /// <returns>string of success message</returns>
        [HttpDelete("{taskId}")]
        public ActionResult<string> DeleteTask(int taskId)
        {
            try
            {
                Task task = this.taskRepository.GetTaskById(taskId);

                if(task == null)
                {
                    return StatusCode(StatusCodes.Status409Conflict); 
                }

                this.taskRepository.DeleteTask(taskId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,ex.Message);
            }
        }

        /// <summary>
        /// task assign to employee
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="empId"></param>
        /// <returns>TaskModel</returns>
        [HttpPatch("{taskId}/assign/{empId}")]
        public ActionResult<TaskModel> AssignTaskToEmployee(int taskId,int empId)
        {
            if(empRepository.GetEmployeeDetailsById(empId) == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }

            if (taskRepository.GetTaskById(taskId) == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }

            TaskModel task = new TaskModel(taskRepository.AssignTaskToEmployee(taskId, empId));
            return task;
        }
    }
}
