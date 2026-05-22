using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Application.Common.Dtos.Projects;
using TaskManagement.Application.Interfaces;

namespace TaskManagement.Application.Features.Projects.Queries
{
    public record GetAllProjectsQuery(Guid UserId) : IRequest<IEnumerable<ProjectResponse>>;

    public class GetAllProjectsQueryHandler(IAppDbContext _context, IMapper _mapper) : IRequestHandler<GetAllProjectsQuery, IEnumerable<ProjectResponse>>
    {
        public async Task<IEnumerable<ProjectResponse>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Projects
                .Where(p => p.UserId == request.UserId.ToString()) 
                .ProjectTo<ProjectResponse>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}
