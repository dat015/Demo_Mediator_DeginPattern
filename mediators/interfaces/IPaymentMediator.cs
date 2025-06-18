using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo_mediator_design_pattern.dtos;

namespace demo_mediator_design_pattern.mediators.interfaces
{
    public interface IPaymentMediator
    {
        Task HandleAsync(int customerId,int orderId, decimal amount);

    }
}