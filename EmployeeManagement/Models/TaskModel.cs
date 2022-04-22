using EmployeeManagement.Entities;
using System;

namespace EmployeeManagement.Models
{
    public class TaskModel
    {
        /// <summary>
        /// constructor of class
        /// </summary>
        public TaskModel()
        {

        }

        /// <summary>
        /// constructor for initialization
        /// </summary>
        /// <param name="task"></param>
        public TaskModel(Task task)
        {
            this.TaskId = task.TaskId;
            this.Title = task.Title;
            this.EmpId = task.EmpId;
            this.StartDate = task.StartDate;
            this.EndDate = task.EndDate;
            this.Priority = task.Priority;
            this.Status = task.Status;
            this.ReportedBy = task.ReportedBy;
        }

        /// <summary>
        /// mapping model properties to entity properties
        /// </summary>
        /// <param name="task"></param>
        /// <param name="taskModel"></param>
        public void MappingModelToEntity(Task task, TaskModel taskModel)
        {
            task.TaskId = taskModel.TaskId;
            task.Title = taskModel.Title;
            task.EmpId = taskModel.EmpId;
            task.StartDate = taskModel.StartDate;
            task.EndDate = taskModel.EndDate;
            task.Status = taskModel.Status;
            task.Priority = taskModel.Priority;
            task.ReportedBy = taskModel.ReportedBy;
        }

        /// <summary>
        /// conversion of model to entity
        /// </summary>
        /// <param name="taskModel"></param>
        /// <returns>Task entity</returns>
        public static implicit operator Task(TaskModel taskModel)
        {
            return new Task
            {
                TaskId = taskModel.TaskId,
                Title = taskModel.Title,
                EmpId = taskModel.EmpId,
                StartDate = taskModel.StartDate,
                EndDate = taskModel.EndDate,
                Priority = taskModel.Priority,
                Status = taskModel.Status,
                ReportedBy = taskModel.ReportedBy
            };
        }

        /// <summary>
        /// Id of task - PK
        /// </summary>
        public int TaskId { get; set; }

        /// <summary>
        /// Id of employee - FK
        /// </summary>
        public int? EmpId { get; set; }

        /// <summary>
        /// title of task
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// start date of task
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// end date of task
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// priority of task
        /// </summary>
        public string Priority { get; set; }

        /// <summary>
        /// status of task
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// person name whom employee need to report
        /// </summary>
        public string ReportedBy { get; set; }
    }
}
