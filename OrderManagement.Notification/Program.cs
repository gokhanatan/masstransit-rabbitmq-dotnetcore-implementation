using System;
using MassTransit;
using OrderManagement.Common;

namespace OrderManagement.Notification
{
    class Program
    {
        static void Main(string[] args)
        {
            var bus = BusConfigurator.ConfigureBus(cfg =>
            {
                cfg.ReceiveEndpoint(MqConstants.NotificationQueue, e =>
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