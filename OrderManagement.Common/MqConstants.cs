namespace OrderManagement.Common
{
    public class MqConstants
    {
        public const string RabbitMqUri = "rabbitmq://localhost/order/";
        public const string UserName = "guest";
        public const string Password = "guest";
        public const string OrderQueue = "ordermanagement.order";
        public const string NotificationQueue = "ordermanagement.notification";
        public const string ThirdPartyServiceQueue = "ordermanagement.thirdpartyservice";
    }
}