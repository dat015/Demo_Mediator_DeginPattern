using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo_mediator_design_pattern.mediators.interfaces;

namespace demo_mediator_design_pattern.services
{
    public class PaymentService
    {
        private readonly IPaymentMediator _mediator;
        public PaymentService(IPaymentMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task ProcessPayment(int customerId, int orderId, decimal amount)
        {
            await _mediator.HandleAsync(customerId, orderId, amount);
        }
    }
}