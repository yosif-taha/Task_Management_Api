using MediatR;
using TaskManagement.Application.Dtos;

namespace TaskManagement.Application.Features.Auth.Commands.Register
{
    public record RegisterCommand(string Username, string Email, string Password) : IRequest<AuthResponse>;
}
