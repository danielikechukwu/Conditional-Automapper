namespace ConditionalAutomapperDemo.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public bool IsShipped { get; set; }

        public decimal ShippingCost { get; set; }

        // Computed or re-verified after mapping
        public decimal OrderTotal { get; set; }

        public List<OrderItemDTO> OrderItems { get; set; }

    }
}
