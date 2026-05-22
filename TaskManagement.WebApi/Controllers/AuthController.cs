using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Common.Dtos.Auth;
using TaskManagement.Application.Features.Auth.Commands.Login;
using TaskManagement.Application.Features.Auth.Commands.Register;

namespace TaskManagement.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(IMediator _mediator) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request, CancellationToken cancellationToken)
        {
            var command = new RegisterCommand(request.Username, request.Email, request.Password);

            var result = await _mediator.Send(command, cancellationToken);

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request, CancellationToken cancellationToken)
        {
            var command = new LoginCommand(request.Email, request.Password);

            var result = await _mediator.Send(command, cancellationToken);

            return Ok(result);
        }
    }
}
