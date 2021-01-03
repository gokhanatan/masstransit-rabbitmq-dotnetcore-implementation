using System;
using MassTransit;
using OrderManagement.Common;

namespace OrderManagement.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            var bus = BusConfigurator.ConfigureBus(cfg =>
            {
                cfg.ReceiveEndpoint(MqConstants.OrderQueue, e =>
                  {
                      e.Consumer<CreateOrderCommandConsumer>();
                  });

            });

            bus.StartAsync();
            Console.WriteLine("Listening for Create Order commands... Press enter to exit");
            Console.ReadLine();
            bus.StopAsync();
        }
    }
}
