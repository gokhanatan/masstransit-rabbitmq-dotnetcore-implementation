using OrderManagement.MessageContracts;

namespace OrderManagement.Api.Models
{
    public class CreateOrderModel : ICreateOrderCommand
    {
        public string OrderCode { get ; set; }
        public string Description { get; set; }
    }
}