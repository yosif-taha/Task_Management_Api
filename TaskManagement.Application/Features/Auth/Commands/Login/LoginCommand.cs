using MediatR;
using TaskManagement.Application.Common.Dtos.Auth;

namespace TaskManagement.Application.Features.Auth.Commands.Login
{
    public record LoginCommand(string Email, string Password) : IRequest<AuthResponse>;
}
