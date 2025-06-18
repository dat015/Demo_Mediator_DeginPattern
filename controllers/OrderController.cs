using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo_mediator_design_pattern.dtos;
using demo_mediator_design_pattern.services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace demo_mediator_design_pattern.controllers
{
    [Route("api/[controller]")]
    public class OrderController : BaseController
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("place-order")]
        public async Task<IActionResult> PlaceOrder([FromBody] OrderRequestDto request)
        {
            try
            {
                // Validate model
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage)
                        .ToList();
                    return ErrorResponse($"Dữ liệu không hợp lệ: {string.Join(", ", errors)}");
                }

                var response = await _orderService.PlaceOrder(request);
                if (response.Success)
                {
                    return SuccessResponse(response, "Đặt hàng thành công");
                }
                return ErrorResponse("Đặt hàng thất bại", response);
            }
            catch (Exception ex)
            {
                return ErrorResponse($"Lỗi: {ex.Message}");
            }
        }

        [HttpGet("get-all-orders")]
        public async Task<IActionResult> GetAllOrder()
        {
            try
            {
                var response = await _orderService.GetAllOrder();
                if (response == null)
                {
                    return ErrorResponse<List<OrderDto>>("Không thể lấy danh sách đơn hàng");
                }
                return SuccessResponse(response, "Lấy danh sách đơn hàng thành công");
            }
            catch (Exception ex)
            {
                return ErrorResponse<List<OrderDto>>($"Lỗi: {ex.Message}");
            }
        }

        [HttpPut("change-status-order")]
        public async Task<IActionResult> ChangeStatusOrder([FromBody] OrderDto request)
        {
            try
            {
                // Validate model
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage)
                        .ToList();
                    return ErrorResponse($"Dữ liệu không hợp lệ: {string.Join(", ", errors)}");
                }

                var response = await _orderService.ChangeStatusOrder(request.id, request.status);
                if (!response)
                {
                    return ErrorResponse("Cập nhật trạng thái đơn hàng thất bại");
                }
                return SuccessResponse("Cập nhật trạng thái đơn hàng thành công");
            }
            catch (Exception ex)
            {
                return ErrorResponse($"Lỗi: {ex.Message}");
            }
        }

        [HttpDelete("delete-order")]
        public async Task<IActionResult> DeleteOrder([FromBody] OrderDto request)
        {
            try
            {
                // Validate model
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage)
                        .ToList();
                    return ErrorResponse($"Dữ liệu không hợp lệ: {string.Join(", ", errors)}");
                }

                var response = await _orderService.DeleteOrder(request.id);
                if (!response)
                {
                    return ErrorResponse("Xóa đơn hàng thất bại");
                }
                return SuccessResponse("Xóa đơn hàng thành công");
            }
            catch (Exception ex)
            {
                return ErrorResponse($"Lỗi: {ex.Message}");
            }
        }
    }
}