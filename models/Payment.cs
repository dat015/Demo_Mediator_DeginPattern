using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace demo_mediator_design_pattern.models
{
    public class Payment
    {
        [Key]
        public int id { get; set; }
        public string type { get; set; }
        public decimal totalPrice { get; set; }
        public int orderId { get; set; }
        public int customerId { get; set; }
        [ForeignKey("orderId")]
        public Order order { get; set; }
    }
}