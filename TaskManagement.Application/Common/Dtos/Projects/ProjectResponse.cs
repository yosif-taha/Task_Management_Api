namespace TaskManagement.Application.Common.Dtos.Projects
{
    public record ProjectResponse(
      Guid Id,
      string Name,
      string Description,
      DateTime CreatedAt
    );
}
