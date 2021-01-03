using System;
using System.Threading.Tasks;
using MassTransit;
using OrderManagement.MessageContracts;

namespace OrderManagement.Notification
{
    public class OrderCreatedEventConsumer : IConsumer<IOrderCreatedEvent>
    {
        public async Task Consume(ConsumeContext<IOrderCreatedEvent> context)
        {
            await Console.Out.WriteLineAsync($"Notification sent: Order Id {context.Message.Id}");
        }
    }
}