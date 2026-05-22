using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Application.Dtos;
using TaskManagement.Application.Interfaces;

namespace TaskManagement.Application.Features.Auth.Commands.Login
{
    public class LoginCommandHandler(IAppDbContext _context, IJwtTokenGenerator _tokenGenerator) 
        : IRequestHandler<LoginCommand, AuthResponse>
    {
        public async Task<AuthResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == request.Email, cancellationToken);

            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                throw new Exception("Invalid email or password."); 
            }

            var token = _tokenGenerator.GenerateToken(user);

            return new AuthResponse(token, user.Username, user.Email);
        }
    }
}
