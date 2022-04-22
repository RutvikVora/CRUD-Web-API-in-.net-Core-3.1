using System;
using System.Collections.Generic;

namespace EmployeeManagement.Entities
{
    public partial class Task
    {
        public int TaskId { get; set; }
        public int? EmpId { get; set; }
        public string Title { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public string ReportedBy { get; set; }

        public virtual Employee Emp { get; set; }
    }
}
