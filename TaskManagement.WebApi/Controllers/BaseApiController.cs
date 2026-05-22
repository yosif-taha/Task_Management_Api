using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskManagement.Application.Common.Wrappers;

namespace TaskManagement.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseApiController : ControllerBase
    {
        private ISender? _mediator;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

        protected Guid CurrentUserId
        {
            get
            {
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                return Guid.TryParse(userIdClaim, out var guid) ? guid : Guid.Empty;
            }
        }

        protected ActionResult<ApiResponse<T>> OkResponse<T>(T data, string message = "")
        {
            return Ok(ApiResponse<T>.Success(data, message));
        }

        protected ActionResult<ApiResponse<object>> OkResponse(string message = "")
        {
            return Ok(ApiResponse<object>.Success(message));
        }
    }
}
