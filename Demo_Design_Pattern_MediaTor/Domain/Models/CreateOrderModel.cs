namespace Demo_Design_Pattern_MediaTor.Domain.Models
{
    public class CreateOrderModel
    {
        public string CustomerName { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
    }
}
