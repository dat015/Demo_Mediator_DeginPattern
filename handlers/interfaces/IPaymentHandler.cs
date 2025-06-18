using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo_mediator_design_pattern.handlers.interfaces
{
    public interface IPaymentHandler
    {
        Task HandleAsync(int customerId, int orderId, decimal price);

    }
}