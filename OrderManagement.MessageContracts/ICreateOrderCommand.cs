namespace OrderManagement.MessageContracts
{
    public interface ICreateOrderCommand
    {
        string OrderCode { get; set; }
        string Description { get; set; }
    }
}