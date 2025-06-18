using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo_mediator_design_pattern.dtos;
using demo_mediator_design_pattern.mediators.interfaces;
using demo_mediator_design_pattern.models;

namespace demo_mediator_design_pattern.services
{
    public class OrderService
    {
        // Dùng Mediator để thực hiện hành động
        //không kết hợp các services khác để thực hiện logic
        private readonly IOrderMediator _mediator;
        public OrderService(IOrderMediator orderMediator)
        {
            _mediator = orderMediator;
        }

        //Xử lý đơn hàng bằng cách gọi hanlder của order mediator
        public async Task<OrderResponseDto> PlaceOrder(OrderRequestDto request)
        {
            return await _mediator.HandleAsync(request);
        }

        public async Task<List<Order>> GetAllOrder()
        {
            return await _mediator.HandleGetAllAsync();
        }

        public async Task<bool> ChangeStatusOrder(int id, string status)
        {
            return await _mediator.HandleChangeStatusAsync(id, status);
        }

        public async Task<bool> DeleteOrder(int id)
        {
            return await _mediator.HandleDeleteOrderAsync(id);

        }

    }
}