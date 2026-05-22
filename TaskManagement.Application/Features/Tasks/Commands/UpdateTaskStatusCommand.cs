using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Application.Interfaces;
using TaskManagement.Domin.Enums;

namespace TaskManagement.Application.Features.Tasks.Commands
{
    public record UpdateTaskStatusCommand(Guid Id, Status Status, Guid UserId) : IRequest<bool>;

    public class UpdateTaskStatusCommandHandler(IAppDbContext _context, IUnitOfWork _unitOfWork) : IRequestHandler<UpdateTaskStatusCommand, bool>
    {
        public async Task<bool> Handle(UpdateTaskStatusCommand request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.ExecuteAsync(async () =>
            {
                var task = await _context.Tasks
                .Include(t => t.Project)
                .FirstOrDefaultAsync(t => t.Id == request.Id && t.Project.UserId == request.UserId.ToString(), cancellationToken);

                if (task == null) return false;

                task.Status = request.Status;
                return true;
            }, cancellationToken);
        }
    }
}
