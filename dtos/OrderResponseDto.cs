using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo_mediator_design_pattern.dtos
{
    public class OrderResponseDto
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}