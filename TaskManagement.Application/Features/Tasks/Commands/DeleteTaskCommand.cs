using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Application.Interfaces;

namespace TaskManagement.Application.Features.Tasks.Commands
{
    public record DeleteTaskCommand(Guid Id, Guid UserId) : IRequest<bool>;

    public class DeleteTaskCommandHandler(IAppDbContext _context, IUnitOfWork _unitOfWork) : IRequestHandler<DeleteTaskCommand, bool>
    {
        public async Task<bool> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.ExecuteAsync(async () =>
            {
                var task = await _context.Tasks
                    .Include(t => t.Project)
                    .FirstOrDefaultAsync(t => t.Id == request.Id && t.Project.UserId == request.UserId.ToString(), cancellationToken);

                if (task == null) return false;

                _context.Tasks.Remove(task);
                return true;
            }, cancellationToken);
        }
    }
}
