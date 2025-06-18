using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace demo_mediator_design_pattern.dtos
{
    public class OrderDto
    {
        [Required(ErrorMessage = "Id là bắt buộc")]
        [Range(1, int.MaxValue, ErrorMessage = "Id phải lớn hơn 0")]
        public int id { get; set; }

        [Required(ErrorMessage = "Status là bắt buộc")]
        [StringLength(50, ErrorMessage = "Status không được vượt quá 50 ký tự")]
        public string status { get; set; }
    }
}