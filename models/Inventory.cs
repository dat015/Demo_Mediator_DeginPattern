using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace demo_mediator_design_pattern.models
{
    public class Inventory
    {
        [Key]
        public int id { get; set; }
        public int productId { get; set; }
        public int quantityInStock { get; set; }
        public DateTime LastUpdated { get; set; } 
        [ForeignKey("productId")]
        public Product product { get; set; }
    }
}