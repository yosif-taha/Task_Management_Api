
namespace TaskManagement.Application.Dtos
{
    public record RegisterRequest(
        string Username,
        string Email,
        string Password
    );
}
