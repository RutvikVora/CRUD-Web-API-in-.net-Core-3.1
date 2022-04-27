namespace EmployeeManagement.Repository.Interfaces
{
    using System.Linq;
    using EmployeeManagement.Entities;
    using EmployeeManagement.Models;
    public interface ITaskRepository
    {
        /// <summary>
        /// get list of all Tasks
        /// </summary>
        /// <returns>list of all tasks</returns>
        IQueryable<Task> GetTasksList(string empId);

        /// <summary>
        /// get Task details by task id
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns>task of particular id</returns>
        Task GetTaskById(int? taskId);

        /// <summary>
        ///  add edit task
        /// </summary>
        /// <param name="taskModel"></param>
        /// <returns>task entity</returns>
        Task UpsertTask(TaskModel taskModel);


        /// <summary>
        /// delete task
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        void DeleteTask(int taskId);

        /// <summary>
        /// task assign to employee
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="id"></param>
        /// <returns>task entity</returns>
        Task AssignTaskToEmployee(int taskId, int id);
    }
}
