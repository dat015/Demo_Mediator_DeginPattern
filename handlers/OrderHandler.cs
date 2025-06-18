using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo_mediator_design_pattern.database;
using demo_mediator_design_pattern.dtos;
using demo_mediator_design_pattern.handlers.interfaces;
using demo_mediator_design_pattern.mediators.interfaces;
using demo_mediator_design_pattern.models;
using demo_mediator_design_pattern.services;
using Microsoft.EntityFrameworkCore;

namespace demo_mediator_design_pattern.handlers
{
    public class OrderHandler : IOrderHandler
    {
        //giao tiếp với các services khác để thực hiện logic order
        private readonly InventoryService _inventoryService;
        private readonly PaymentService _paymentService;
        private readonly ApplicationDbContext _context;

        public OrderHandler(InventoryService inventoryService, PaymentService paymentService, ApplicationDbContext context)
        {
            _inventoryService = inventoryService;
            _paymentService = paymentService;
            _context = context;
        }

        public async Task<OrderResponseDto> HandleAsync(OrderRequestDto request)
        {
            try
            {
                var isInStock = await _inventoryService.CheckStock(request.productId, request.Quantity);
                if (!isInStock)
                {
                    return new OrderResponseDto
                    {
                        Message = "Khong du san pham trong kho",
                        Success = false
                    };
                }
                var newOrder = new Order
                {
                    price = request.price,
                    quantity = request.Quantity,
                    customerId = request.customerId
                };

                _context.Orders.Add(newOrder);
                await _context.SaveChangesAsync();

                _inventoryService.UpdateStock(request.productId, request.Quantity);
                await _paymentService.ProcessPayment(request.customerId, newOrder.id, (decimal)(request.Quantity * request.price));
                return new OrderResponseDto
                {
                    Message = "Thanh cong",
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new OrderResponseDto
                {
                    Message = ex.Message,
                    Success = false
                };
            }

        }

        public async Task<bool> HandleChangeStatusAsync(int id, string status)
        {
            try
            {
                var existingOrder = await _context.Orders.FindAsync(id);
                if (existingOrder == null)
                {
                    return false;
                }
                existingOrder.status = status;
                _context.Orders.Update(existingOrder);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> HandleDeleteOrderAsync(int id)
        {
            try
            {
                var existingOrder = await _context.Orders.FindAsync(id);
                if (existingOrder == null)
                {
                    return false;
                }

                _context.Orders.Remove(existingOrder);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Order>> HandleGetAllAsync()
        {
            var listOrder = await _context.Orders
                .ToListAsync();
            return (listOrder == null) ? new List<Order>() : listOrder;
        }
    }
}