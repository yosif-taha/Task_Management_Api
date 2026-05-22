using MediatR;
using TaskManagement.Application.Common.Dtos.Auth;

namespace TaskManagement.Application.Features.Auth.Commands.Register
{
    public record RegisterCommand(string Username, string Email, string Password) : IRequest<AuthResponse>;
}
