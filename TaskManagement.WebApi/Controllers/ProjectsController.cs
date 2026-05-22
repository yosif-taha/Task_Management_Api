using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Common.Dtos.Projects;
using TaskManagement.Application.Common.Wrappers;
using TaskManagement.Application.Features.Projects.Commands;
using TaskManagement.Application.Features.Projects.Queries;

namespace TaskManagement.WebApi.Controllers
{
    [Authorize] 
    public class ProjectsController : BaseApiController
    {
        [HttpPost]
        public async Task<ActionResult<ApiResponse<ProjectResponse>>> Create([FromBody] CreateProjectRequest request, CancellationToken cancellationToken)
        {
            var command = new CreateProjectCommand(request.Name, request.Description, CurrentUserId);
            var result = await Mediator.Send(command, cancellationToken);
            return OkResponse(result, "Project created successfully.");
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<ProjectResponse>>>> GetAll(CancellationToken cancellationToken)
        {
            var query = new GetAllProjectsQuery(CurrentUserId);
            var result = await Mediator.Send(query, cancellationToken);
            return OkResponse(result, "Projects retrieved successfully.");
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ApiResponse<ProjectResponse>>> GetById(Guid id, CancellationToken cancellationToken)
        {
            var query = new GetProjectByIdQuery(id, CurrentUserId);
            var result = await Mediator.Send(query, cancellationToken);

            if (result == null)
                return NotFound(ApiResponse<object>.Fail("Project not found."));

            return OkResponse(result, "Project retrieved successfully.");
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ApiResponse<object>>> Update(Guid id, [FromBody] UpdateProjectRequest request, CancellationToken cancellationToken)
        {
            var command = new UpdateProjectCommand(id, request.Name, request.Description, CurrentUserId);
            var result = await Mediator.Send(command, cancellationToken);

            if (!result)
                return NotFound(ApiResponse<object>.Fail("Project not found or you don't have permission to update it."));

            return OkResponse("Project updated successfully.");
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ApiResponse<object>>> Delete(Guid id, CancellationToken cancellationToken)
        {
            var command = new DeleteProjectCommand(id, CurrentUserId);
            var result = await Mediator.Send(command, cancellationToken);

            if (!result)
                return NotFound(ApiResponse<object>.Fail("Project not found or you don't have permission to delete it."));

            return OkResponse("Project deleted successfully.");
        }
    }
}
