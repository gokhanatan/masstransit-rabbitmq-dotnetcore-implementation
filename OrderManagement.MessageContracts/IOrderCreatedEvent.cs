using System;

namespace OrderManagement.MessageContracts
{
    public interface IOrderCreatedEvent
    {
        Guid Id { get; set; }
    }
}