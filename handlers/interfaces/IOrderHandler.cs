using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo_mediator_design_pattern.dtos;
using demo_mediator_design_pattern.models;

namespace demo_mediator_design_pattern.handlers.interfaces
{
    public interface IOrderHandler
    {
        Task<OrderResponseDto> HandleAsync(OrderRequestDto request);
        Task<List<Order>> HandleGetAllAsync();
        Task<bool> HandleChangeStatusAsync(int id, string status);
        Task<bool> HandleDeleteOrderAsync(int id);
    }
}