using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Application.Common.Dtos.Projects;
using TaskManagement.Application.Interfaces;

namespace TaskManagement.Application.Features.Projects.Queries
{
    public record GetProjectByIdQuery(Guid Id, Guid UserId) : IRequest<ProjectResponse?>;

    public class GetProjectByIdQueryHandler(IAppDbContext _context, IMapper _mapper) : IRequestHandler<GetProjectByIdQuery, ProjectResponse?>
    {


        public async Task<ProjectResponse?> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var project = await _context.Projects
                .FirstOrDefaultAsync(p => p.Id == request.Id && p.UserId == request.UserId.ToString(), cancellationToken);

            if (project == null)
                return null;

            return _mapper.Map<ProjectResponse>(project);
        }
    }
}
