using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo_mediator_design_pattern.handlers.interfaces
{
    public interface IInventoryHandler
    {
        Task<bool> HandleAsync(int productId, int quantity);
        Task HandleUpdateAsync(int productId, int quantity);
    }
}