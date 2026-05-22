using TaskManagement.Domin.Common;
using TaskManagement.Domin.Enums;

namespace TaskManagement.Domin.Models
{
    public class ProjectTask : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Status Status { get; set; } = Status.Todo;
        public TaskPriority Priority { get; set; } = TaskPriority.Medium;
        public DateTime? DueDate { get; set; }
        public Guid ProjectId { get; set; }
        public Project Project { get; set; } = null!;
    }
}
