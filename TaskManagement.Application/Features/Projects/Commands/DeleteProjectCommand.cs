using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Application.Interfaces;

namespace TaskManagement.Application.Features.Projects.Commands
{
    public record DeleteProjectCommand(Guid Id, Guid UserId) : IRequest<bool>;

    public class DeleteProjectCommandHandler(IAppDbContext _context, IUnitOfWork _unitOfWork)
        : IRequestHandler<DeleteProjectCommand, bool>
    {

        public async Task<bool> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.ExecuteAsync(async () =>
            {
                var project = await _context.Projects
                .FirstOrDefaultAsync(p => p.Id == request.Id && p.UserId == request.UserId.ToString(), cancellationToken);

                if (project == null)
                    return false;

                _context.Projects.Remove(project);
                return true;
            }, cancellationToken);
        }
    }
}
