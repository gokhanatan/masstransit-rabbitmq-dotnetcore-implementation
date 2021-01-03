using System;
using System.Threading.Tasks;
using MassTransit;
using OrderManagement.MessageContracts;

namespace OrderManagement.Service
{
    public class CreateOrderCommandConsumer : IConsumer<ICreateOrderCommand>
    {
        public Task Consume(ConsumeContext<ICreateOrderCommand> context)
        {
            var message = context.Message;
            var orderId = Guid.NewGuid();
            Console.WriteLine($"Order created successfully. OrderCode:{message.OrderCode}, Description:{message.Description}, Id:{orderId}");
            context.Publish<IOrderCreatedEvent>(new
            {
                Id = orderId
            });
            
            return Task.CompletedTask;
        }
    }
}