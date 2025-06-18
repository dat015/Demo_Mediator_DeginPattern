using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo_mediator_design_pattern.dtos;
using demo_mediator_design_pattern.services;
using Microsoft.AspNetCore.Mvc;

namespace demo_mediator_design_pattern.controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("place-order")]
        public async Task<IActionResult> PlaceOrder([FromBody] OrderRequestDto request)
        {
            var response = await _orderService.PlaceOrder(request);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("get-all-orders")]
        public async Task<IActionResult> GetAllOrder()
        {
            var response = await _orderService.GetAllOrder();
            if (response == null)
            {
                return BadRequest();
            }
            return Ok(new
            {
                data = response
            });
        }

        [HttpPut("change-status-order")]
        public async Task<IActionResult> ChangeStatusOrder([FromBody] OrderDto request)
        {
            try
            {
                var response = await _orderService.ChangeStatusOrder(request.id, request.status);
                if (!response)
                {
                    return BadRequest(
                    new
                    {
                        Message = "That bai",
                        Success = false
                    }
                );
                }
                return Ok(
                      new
                      {
                          Message = "Thanh cong",
                          Success = true
                      }
                );
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new
                    {
                        Message = ex.Message,
                        Success = false
                    }
                );
            }
        }
        [HttpDelete("delete-order")]
        public async Task<IActionResult> DeleteOrder([FromBody] OrderDto request)
        {
            try
            {
                var response = await _orderService.DeleteOrder(request.id);
                if (!response)
                {
                    return BadRequest(
                        new
                        {
                            Message = "That bai",
                            Success = false
                        }
                    );
                }
                return Ok(
                    new
                        {
                            Message = "Thanh cong",
                            Success = true
                        }
                );

            }
            catch (Exception ex)
            {
                return BadRequest(
                   new
                   {
                       Message = ex.Message,
                       Success = false
                   }
               );
            }
        }
    }
}