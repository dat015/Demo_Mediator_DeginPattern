using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo_mediator_design_pattern.services
{
    public class NotificationService
    {
        public void SendNotification(string customerId, string message)
        {
            Console.WriteLine($"Gửi thông báo tới {customerId}: {message}");
        }
    }
}