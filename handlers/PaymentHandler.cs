using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo_mediator_design_pattern.database;
using demo_mediator_design_pattern.handlers.interfaces;
using demo_mediator_design_pattern.models;

namespace demo_mediator_design_pattern.handlers
{
    public class PaymentHandler : IPaymentHandler
    {
        private readonly ApplicationDbContext _context;
        public PaymentHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task HandleAsync(int customerId, int orderId, decimal price)
        {
            var newPayment = new Payment
            {
                type = "banking",
                customerId = customerId,
                orderId = orderId,
                totalPrice = price
            };
            _context.Payments.Add(newPayment);
            await _context.SaveChangesAsync();
        }
    }
}