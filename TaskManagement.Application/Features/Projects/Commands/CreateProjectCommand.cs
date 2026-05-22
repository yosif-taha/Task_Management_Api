using AutoMapper;
using MediatR;
using TaskManagement.Application.Common.Dtos.Projects;
using TaskManagement.Application.Interfaces;
using TaskManagement.Domin.Models;

namespace TaskManagement.Application.Features.Projects.Commands
{
    public record CreateProjectCommand(string Name, string Description, Guid UserId) : IRequest<ProjectResponse>;

    public class CreateProjectCommandHandler(IAppDbContext _context, IMapper _mapper, IUnitOfWork _unitOfWork) 
        : IRequestHandler<CreateProjectCommand, ProjectResponse>
    {


        public async Task<ProjectResponse> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.ExecuteAsync(async () =>
            {
                var project = new Project
                {
                    Id = Guid.NewGuid(),
                    Name = request.Name,
                    Description = request.Description,
                    CreatedAt = DateTime.UtcNow,
                    UserId = request.UserId.ToString()
                };
                _context.Projects.Add(project);

                return _mapper.Map<ProjectResponse>(project);
            } , cancellationToken);
        }
    }
}
