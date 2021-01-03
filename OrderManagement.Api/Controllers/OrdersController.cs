using System;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderManagement.Api.Models;
using OrderManagement.Common;
using OrderManagement.MessageContracts;

namespace OrderManagement.Api.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly ILogger<OrdersController> _logger;
        private readonly IBusControl _bus;
        public OrdersController(ILogger<OrdersController> logger)
        {
            _logger = logger;
            _bus = BusConfigurator.ConfigureBus();
        }

        [Route("post")]
        [HttpPost]
        public IActionResult Post([FromBody] CreateOrderModel createOrderModel)
        {
            CreateOrder(createOrderModel);
            return Ok("The order request has been successful!");
        }

        private void CreateOrder(CreateOrderModel createOrderModel)
        {
            var sendToUri = new Uri($"{MqConstants.RabbitMqUri}{MqConstants.OrderQueue}");
            var endPoint = _bus.GetSendEndpoint(sendToUri).Result;

            endPoint.Send<ICreateOrderCommand>(createOrderModel).Wait();
        }
    }
}