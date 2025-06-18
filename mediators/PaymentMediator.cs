using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo_mediator_design_pattern.dtos;
using demo_mediator_design_pattern.handlers.interfaces;
using demo_mediator_design_pattern.mediators.interfaces;

namespace demo_mediator_design_pattern.mediators
{
    
    public class PaymentMediator : IPaymentMediator
    {
        private readonly IPaymentHandler _handler;
        public PaymentMediator(IPaymentHandler handler)
        {
            _handler = handler;
        }
        public async Task HandleAsync(int customerId, int orderId, decimal amount)
        {
            await _handler.HandleAsync(customerId,orderId, amount);
        }
    }
}