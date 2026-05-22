using TaskManagement.Domin.Enums;

namespace TaskManagement.Application.Common.Dtos.Tasks
{
    public record TaskResponse(
     Guid Id,
     string Title,
     string Description,
     Status Status,
     TaskPriority Priority,
     DateTime? DueDate,
     Guid ProjectId
    );
}
