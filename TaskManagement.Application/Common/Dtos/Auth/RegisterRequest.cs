namespace TaskManagement.Application.Common.Dtos.Auth
{
    public record RegisterRequest(
        string Username,
        string Email,
        string Password
    );
}
