using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace demo_mediator_design_pattern.dtos
{
    public class OrderRequestDto
    {
        public int productId { get; set; }
        public int customerId { get; set; }
        public decimal price { get; set; }
        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }
    }
}