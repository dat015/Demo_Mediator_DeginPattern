using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo_mediator_design_pattern.models;
using Microsoft.EntityFrameworkCore;

namespace demo_mediator_design_pattern.database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet cho các thực thể
        public DbSet<Product> Products { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        // Các cấu hình khác nếu có
    }
}
