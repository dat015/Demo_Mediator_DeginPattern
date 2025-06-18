using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace demo_mediator_design_pattern.models
{
    public class Order
    {
        [Key]
        public int id { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }
        public int customerId { get; set; }
        public string status { get; set; } = "Pendding";
    }
}