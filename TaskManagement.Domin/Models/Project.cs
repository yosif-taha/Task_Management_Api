using TaskManagement.Domin.Common;

namespace TaskManagement.Domin.Models
{
    public class Project : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public ICollection<ProjectTask> Tasks { get; set; } = new List<ProjectTask>();
    }
}
