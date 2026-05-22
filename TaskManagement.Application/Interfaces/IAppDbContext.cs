using Microsoft.EntityFrameworkCore;
using TaskManagement.Domin.Models;

namespace TaskManagement.Application.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<User> Users { get; }
        DbSet<Project> Projects { get; }
        DbSet<ProjectTask> Tasks { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
