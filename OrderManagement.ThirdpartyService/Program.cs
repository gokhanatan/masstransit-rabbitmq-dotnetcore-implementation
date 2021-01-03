using System;
using MassTransit;
using OrderManagement.Common;

namespace OrderManagement.ThirdpartyService
{
    class Program
    {
        static void Main(string[] args)
        {
             var bus = BusConfigurator.ConfigureBus(cfg =>
            {
                cfg.ReceiveEndpoint(MqConstants.ThirdPartyServiceQueue, e =>
                  {
                      e.Consumer<OrderCreatedEventConsumer>();
                  });

            });

            bus.StartAsync();
            Console.WriteLine("Listening for OrderCreated events... Press enter to exit");
            Console.ReadLine();
            bus.StopAsync();
        }
    }
}
