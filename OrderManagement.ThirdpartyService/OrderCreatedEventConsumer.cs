using System;
using System.Threading.Tasks;
using MassTransit;
using OrderManagement.MessageContracts;

namespace OrderManagement.ThirdpartyService
{
    public class OrderCreatedEventConsumer : IConsumer<IOrderCreatedEvent>
    {
        public async Task Consume(ConsumeContext<IOrderCreatedEvent> context)
        {
            await Console.Out.WriteLineAsync($"Message send to Thirdpary Service: Order id {context.Message.Id}");
        }
    }
}