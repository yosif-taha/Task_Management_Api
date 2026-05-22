using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Common.Dtos.Tasks;
using TaskManagement.Application.Common.Wrappers;
using TaskManagement.Application.Features.Tasks.Commands;
using TaskManagement.Application.Features.Tasks.Queries;

namespace TaskManagement.WebApi.Controllers
{
    [Authorize]
    public class TasksController : BaseApiController
    {
        [HttpPost]
        public async Task<ActionResult<ApiResponse<TaskResponse>>> Create([FromBody] CreateTaskRequest request, CancellationToken cancellationToken)
        {
            var command = new CreateTaskCommand(
                request.Title,
                request.Description,
                request.Priority,
                request.DueDate,
                request.ProjectId,
                CurrentUserId
            );

            var result = await Mediator.Send(command, cancellationToken);

            if (result == null)
                return NotFound(ApiResponse<object>.Fail("Project not found or you don't have permission to add tasks to it."));

            return OkResponse(result, "Task created successfully.");
        }

        [HttpGet("project/{projectId:guid}")]
        public async Task<ActionResult<ApiResponse<IEnumerable<TaskResponse>>>> GetByProject(Guid projectId, CancellationToken cancellationToken)
        {
            var query = new GetTasksByProjectQuery(projectId, CurrentUserId);
            var result = await Mediator.Send(query, cancellationToken);

            if (result == null)
                return NotFound(ApiResponse<object>.Fail("Project not found or you don't have permission to view its tasks."));

            return OkResponse(result, "Tasks retrieved successfully.");
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ApiResponse<object>>> UpdateStatus(Guid id, [FromBody] UpdateTaskStatusRequest request, CancellationToken cancellationToken)
        {
            var command = new UpdateTaskStatusCommand(id, request.Status, CurrentUserId);
            var result = await Mediator.Send(command, cancellationToken);

            if (!result)
                return NotFound(ApiResponse<object>.Fail("Task not found or you don't have permission to update it."));

            return OkResponse("Task status updated successfully.");
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ApiResponse<object>>> Delete(Guid id, CancellationToken cancellationToken)
        {
            var command = new DeleteTaskCommand(id, CurrentUserId);
            var result = await Mediator.Send(command, cancellationToken);

            if (!result)
                return NotFound(ApiResponse<object>.Fail("Task not found or you don't have permission to delete it."));

            return OkResponse("Task deleted successfully.");
        }
    }
}
