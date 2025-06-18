using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo_mediator_design_pattern.mediators.interfaces;

namespace demo_mediator_design_pattern.services
{
    public class InventoryService
    {
        private readonly IInventoryMediator _mediator;
        public InventoryService(IInventoryMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<bool> CheckStock(int productId, int quantity)
        {
            return await _mediator.HandleAsync(productId, quantity);
        }

        public void UpdateStock(int productId, int quantity)
        {
            _mediator.HandleUpdateAsync(productId, quantity);
        }
    }
}