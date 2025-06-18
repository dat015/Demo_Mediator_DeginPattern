using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo_mediator_design_pattern.database;
using demo_mediator_design_pattern.dtos;
using demo_mediator_design_pattern.handlers.interfaces;
using demo_mediator_design_pattern.mediators.interfaces;
using Microsoft.EntityFrameworkCore;

namespace demo_mediator_design_pattern.mediators
{
    public class InventoryMediator : IInventoryMediator
    {
        private readonly IInventoryHandler _handler;
        public InventoryMediator(IInventoryHandler handler)
        {
            _handler = handler;
        }

        public async Task<bool> HandleAsync(int productId, int quantity)
        {
            return await _handler.HandleAsync(productId, quantity);
        }

        public async Task HandleUpdateAsync(int productId, int quantity)
        {
            await _handler.HandleUpdateAsync(productId,quantity);
        }
    }
}