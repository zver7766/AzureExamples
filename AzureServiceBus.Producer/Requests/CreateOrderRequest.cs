using System;

namespace AzureServiceBus.Producer.Requests
{
    public class CreateOrderRequest
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string ProductName { get; set; }
    }
}