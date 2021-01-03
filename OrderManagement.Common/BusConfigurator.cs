using System;
using MassTransit;
using MassTransit.RabbitMqTransport;

namespace OrderManagement.Common
{
    public static class BusConfigurator
    {
        public static IBusControl ConfigureBus(Action<IRabbitMqBusFactoryConfigurator> registrationAction = null)
        {
            return Bus.Factory.CreateUsingRabbitMq(cfg =>
             {
                 cfg.Host(new Uri(MqConstants.RabbitMqUri), hst =>
                 {
                     hst.Username(MqConstants.UserName);
                     hst.Password(MqConstants.Password);
                 });

              registrationAction?.Invoke(cfg);
             });
        }
    }
}