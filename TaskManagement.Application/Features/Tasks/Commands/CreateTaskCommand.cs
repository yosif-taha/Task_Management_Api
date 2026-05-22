using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Application.Common.Dtos.Tasks;
using TaskManagement.Application.Interfaces;
using TaskManagement.Domin.Enums;
using TaskManagement.Domin.Models;

namespace TaskManagement.Application.Features.Tasks.Commands
{
    public record CreateTaskCommand(
        string Title,
        string Description,
        TaskPriority Priority,
        DateTime? DueDate,
        Guid ProjectId,
        Guid UserId
    ) : IRequest<TaskResponse?>;

    public class CreateTaskCommandHandler(IAppDbContext _context, IMapper _mapper, IUnitOfWork _unitOfWork)
        : IRequestHandler<CreateTaskCommand, TaskResponse?>
    {
        public async Task<TaskResponse?> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.ExecuteAsync(async () =>
            {
                var projectExists = await _context.Projects
                .AnyAsync(p => p.Id == request.ProjectId && p.UserId == request.UserId.ToString(), cancellationToken);

                if (!projectExists) return null;

                var task = new ProjectTask
                {
                    Id = Guid.NewGuid(),
                    Title = request.Title,
                    Description = request.Description,
                    Status = Status.Todo,
                    Priority = request.Priority,
                    DueDate = request.DueDate,
                    ProjectId = request.ProjectId
                };

                _context.Tasks.Add(task);

                return _mapper.Map<TaskResponse>(task);
            }, cancellationToken);
        }
    }
}
