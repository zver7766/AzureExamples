using System;
using System.IO;
using System.Threading.Tasks;
using AzureServiceBus.Contracts;
using AzureServiceBus.Producer.Requests;
using AzureServiceBus.Producer.Services;
using Microsoft.AspNetCore.Mvc;

namespace AzureServiceBus.Producer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessagingController : ControllerBase
    {
        private readonly IMessagePublisher _messagePublisher;

        public MessagingController(IMessagePublisher messagePublisher)
        {
            _messagePublisher = messagePublisher;
        }

        [HttpPost("publish/text")]
        public async Task<IActionResult> PublishText()
        {
            using var reader = new StreamReader(Request.Body);
            var bodyAsText = await reader.ReadToEndAsync();
            await _messagePublisher.Publish(bodyAsText);
            return Ok();
        }

        [HttpPost("publish/customer")]
        public async Task<IActionResult> PublishCustomer([FromBody] CreateCustomerRequest request)
        {
            var customerCreated = new CustomerCreated
            {
                Id = request.Id,
                FullName = request.FullName,
                DateOfBirth = request.DateOfBirth
            };
            await _messagePublisher.Publish(customerCreated);
            return Ok();
        }
        
        [HttpPost("publish/order")]
        public async Task<IActionResult> PublishOrder([FromBody] CreateOrderRequest request)
        {
            var orderCreated = new OrderCreated()
            {
                Id = request.Id,
                ProductName = request.ProductName
            };
            await _messagePublisher.Publish(orderCreated);
            return Ok();
        }    }
}