using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo_mediator_design_pattern.database;
using demo_mediator_design_pattern.handlers.interfaces;
using Microsoft.EntityFrameworkCore;

namespace demo_mediator_design_pattern.handlers
{
    public class InventoryHandler : IInventoryHandler
    {
        private readonly ApplicationDbContext _context;
        public InventoryHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> HandleAsync(int productId, int quantity)
        {
            var inventoryProduct = await _context.Inventories
                .Where(i => i.productId == productId)
                .FirstOrDefaultAsync();
            if (inventoryProduct == null) return false;
            if (inventoryProduct.quantityInStock >= quantity) return true;
            return false;
        }

        public async Task HandleUpdateAsync(int productId, int quantity)
        {
            var inventoryProduct = await _context.Inventories
                .Where(i => i.productId == productId)
                .FirstOrDefaultAsync();
            if (inventoryProduct == null) return;
            inventoryProduct.quantityInStock -= quantity;
            _context.Inventories.Update(inventoryProduct);
            await _context.SaveChangesAsync();
        }
    }
}