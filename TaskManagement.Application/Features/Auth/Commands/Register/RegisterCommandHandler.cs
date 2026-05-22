using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Application.Dtos;
using TaskManagement.Application.Interfaces;
using TaskManagement.Domin.Models;

namespace TaskManagement.Application.Features.Auth.Commands.Register
{
    public class RegisterCommandHandler(IAppDbContext _context, IJwtTokenGenerator _tokenGenerator)
        : IRequestHandler<RegisterCommand, AuthResponse>
    {
        public async Task<AuthResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var userExists = await _context.Users.AnyAsync(u => u.Email == request.Email, cancellationToken);
            if (userExists)
                throw new Exception("Email is already registered.");

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var user = new User
            {
                Username = request.Username,
                Email = request.Email,
                PasswordHash = passwordHash
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync(cancellationToken);

            var token = _tokenGenerator.GenerateToken(user);

            return new AuthResponse(token, user.Username, user.Email);
        }
    }
}
