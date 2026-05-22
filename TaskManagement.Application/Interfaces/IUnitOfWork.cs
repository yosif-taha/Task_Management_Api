
namespace TaskManagement.Application.Interfaces
{
    public interface IUnitOfWork
    {
        public Task<T> ExecuteAsync<T>(Func<Task<T>> action, CancellationToken cancellationToken);
    }
}
