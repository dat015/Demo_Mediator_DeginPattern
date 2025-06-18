using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace demo_mediator_design_pattern.dtos
{
    public class OrderRequestDto
    {
        [Required(ErrorMessage = "ProductId là bắt buộc")]
        [Range(1, int.MaxValue, ErrorMessage = "ProductId phải lớn hơn 0")]
        public int productId { get; set; }

        [Required(ErrorMessage = "CustomerId là bắt buộc")]
        [Range(1, int.MaxValue, ErrorMessage = "CustomerId phải lớn hơn 0")]
        public int customerId { get; set; }

        [Required(ErrorMessage = "Price là bắt buộc")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price phải lớn hơn 0")]
        public decimal price { get; set; }

        [Required(ErrorMessage = "Quantity là bắt buộc")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity phải lớn hơn 0")]
        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }
    }
}