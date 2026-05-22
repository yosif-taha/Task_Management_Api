using TaskManagement.Domin.Enums;

namespace TaskManagement.Application.Common.Dtos.Tasks
{
    public record CreateTaskRequest(
      string Title,
      string Description,
      TaskPriority Priority,
      DateTime? DueDate,
      Guid ProjectId
  );
}
