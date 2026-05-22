using AutoMapper;
using TaskManagement.Application.Common.Dtos.Projects;
using TaskManagement.Domin.Models;

namespace TaskManagement.Application.Common.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Project, ProjectResponse>();
        }
    }
}
