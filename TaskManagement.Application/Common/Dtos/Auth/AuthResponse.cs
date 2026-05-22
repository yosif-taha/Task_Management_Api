namespace TaskManagement.Application.Common.Dtos.Auth
{
    public record AuthResponse(
     string Token,
     string Username,
     string Email
 );
}
