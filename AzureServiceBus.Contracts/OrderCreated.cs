using System;

namespace AzureServiceBus.Contracts
{
    public class OrderCreated
    {
        public Guid Id { get; set; }
        
        public string ProductName { get; set; }
    }
}