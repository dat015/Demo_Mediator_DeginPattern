using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo_mediator_design_pattern.handlers.interfaces;

namespace demo_mediator_design_pattern.handlers
{
    public class InventoryHandler : IInventoryHandler
    {
        public Task<bool> HandleAsync(int productId, int quantity)
        {
            throw new NotImplementedException();
        }

        public Task HandleUpdateAsync(int productId, int quantity)
        {
            throw new NotImplementedException();
        }
    }
}