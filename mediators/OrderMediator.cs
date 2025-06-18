using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo_mediator_design_pattern.dtos;
using demo_mediator_design_pattern.handlers.interfaces;
using demo_mediator_design_pattern.mediators.interfaces;
using demo_mediator_design_pattern.models;

namespace demo_mediator_design_pattern.mediators
{
    public class OrderMediator : IOrderMediator
    {
        //goi IOrderHandler để xử lý logic
        private readonly IOrderHandler _handler;
        public OrderMediator(IOrderHandler handler)
        {
            _handler = handler;
        }
        public async Task<OrderResponseDto> HandleAsync(OrderRequestDto request)
        {
            return await _handler.HandleAsync(request);
        }

        public async Task<bool> HandleChangeStatusAsync(int id, string status)
        {
            return await _handler.HandleChangeStatusAsync(id,status);
        }

        public async Task<bool> HandleDeleteOrderAsync(int id)
        {
            return await _handler.HandleDeleteOrderAsync(id);
        }

        public async Task<List<Order>> HandleGetAllAsync()
        {
            return await _handler.HandleGetAllAsync();

        }
    }
}