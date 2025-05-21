namespace ConditionalAutomapperDemo.DTOs
{
    public class OrderItemDTO
    {
        public int Id { get; set; }

        public string? ProductName { get; set; }  // We will map from Product.Name

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Discount { get; set; }

        // SubTotal might be computed or mapped
        public decimal SubTotal { get; set; }
    }
}
