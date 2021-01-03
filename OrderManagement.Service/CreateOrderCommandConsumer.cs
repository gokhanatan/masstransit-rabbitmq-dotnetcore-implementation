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
            Console.WriteLine($"Order created successfully. OrderCode:{message.OrderCode}, Description:{message.Description}");
 
            return Task.CompletedTask;
        }
    }
}