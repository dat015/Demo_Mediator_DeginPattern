using Microsoft.AspNetCore.Mvc;
using demo_mediator_design_pattern.dtos;

namespace demo_mediator_design_pattern.controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected IActionResult SuccessResponse<T>(T data, string message = "Thành công")
        {
            return Ok(ApiResponse<T>.SuccessResponse(data, message));
        }

        protected IActionResult SuccessResponse(string message = "Thành công")
        {
            return Ok(ApiResponse.SuccessResponse(message));
        }

        protected IActionResult ErrorResponse<T>(string message, T data = default)
        {
            return BadRequest(ApiResponse<T>.ErrorResponse(message, data));
        }

        protected IActionResult ErrorResponse(string message)
        {
            return BadRequest(ApiResponse.ErrorResponse(message));
        }

        protected IActionResult NotFoundResponse(string message = "Không tìm thấy dữ liệu")
        {
            return NotFound(ApiResponse.ErrorResponse(message));
        }

        protected IActionResult UnauthorizedResponse(string message = "Không có quyền truy cập")
        {
            return Unauthorized(ApiResponse.ErrorResponse(message));
        }
    }
} 