using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Application.Interfaces;

namespace TaskManagement.Application.Features.Projects.Commands
{
    public record UpdateProjectCommand(Guid Id, string Name, string Description, Guid UserId) : IRequest<bool>;

    public class UpdateProjectCommandHandler(IAppDbContext _context, IUnitOfWork _unitOfWork) 
        : IRequestHandler<UpdateProjectCommand, bool>
    {
        public async Task<bool> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.ExecuteAsync(async () =>
            {
                var project = await _context.Projects
                .FirstOrDefaultAsync(p => p.Id == request.Id && p.UserId == request.UserId.ToString(), cancellationToken);

                if (project == null)
                    return false;

                project.Name = request.Name;
                project.Description = request.Description;

                return true;
            }, cancellationToken);
        }
    }
}
