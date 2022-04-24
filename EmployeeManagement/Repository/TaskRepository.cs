namespace EmployeeManagement.Repository
{
    using EmployeeManagement.Entities;
    using EmployeeManagement.Models;
    using EmployeeManagement.Repository.Interfaces;
    using System;
    using System.Linq;

    public class TaskRepository : RepositoryBase<Task>, ITaskRepository
    {
        
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="context"></param>
        public TaskRepository(EmployeeManagementContext employeeManagementContext) : base(employeeManagementContext)
        {
            
        }

        /// <summary>
        /// get list of all tasks
        /// </summary>
        /// <returns>list of all tasks</returns>
        public IQueryable<Task> GetTasksList()
        {
            return this.Find();
        }

        /// <summary>
        /// Get Task Details By Id
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns>task of particular Id</returns>
        public Task GetTaskById(int? taskId)
        {
            return this.Find(x => x.TaskId == taskId).FirstOrDefault();
        }

        /// <summary>
        ///  add or edit task
        /// </summary>
        /// <param name="taskModel"></param>
        /// <returns>Task Entity</returns>
        public Task UpsertTask(TaskModel taskModel)
        {
            try
            {
                Task taskDb = GetTaskById(taskModel.TaskId);
                if (taskDb != null)
                {
                    taskModel.MappingModelToEntity(taskDb, taskModel);

                    this.UpdateEntity(taskDb);
                    this.Save();
                    return taskDb;

                }
                else
                {
                    Task task = taskModel;
                    this.CreateEntity(task);
                    this.Save();
                    return task;

                }

            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// delete tasks
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        public void DeleteTask(int taskId)
        {
            Task task = this.Find(x => x.TaskId == taskId).FirstOrDefault();
            this.DeleteEntity(task);
            this.Save();
        }

        /// <summary>
        /// Assign Task to Employee
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="id"></param>
        /// <returns>Task Entity</returns>
        public Task AssignTaskToEmployee(int taskId, int empId)
        {
            Task task = this.Find(x => x.TaskId == taskId).FirstOrDefault();

                task.EmpId = empId;
                this.UpdateEntity(task);
                this.Save();
                return task;
        }
    }
}
