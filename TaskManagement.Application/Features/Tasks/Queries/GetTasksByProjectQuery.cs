using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Application.Common.Dtos.Tasks;
using TaskManagement.Application.Interfaces;

namespace TaskManagement.Application.Features.Tasks.Queries
{
    public record GetTasksByProjectQuery(Guid ProjectId, Guid UserId) : IRequest<IEnumerable<TaskResponse>?>;

    public class GetTasksByProjectQueryHandler(IAppDbContext _context, IMapper _mapper) : IRequestHandler<GetTasksByProjectQuery, IEnumerable<TaskResponse>?>
    {
        public async Task<IEnumerable<TaskResponse>?> Handle(GetTasksByProjectQuery request, CancellationToken cancellationToken)
        {
            var projectExists = await _context.Projects
                .AnyAsync(p => p.Id == request.ProjectId && p.UserId == request.UserId.ToString(), cancellationToken);

            if (!projectExists)
                return null;

            return await _context.Tasks
                .Where(t => t.ProjectId == request.ProjectId)
                .ProjectTo<TaskResponse>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}
