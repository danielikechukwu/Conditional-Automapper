using System.ComponentModel.DataAnnotations.Schema;

namespace ConditionalAutomapperDemo.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Discount { get; set; }

        // Navigation to Product
        public int ProductId { get; set; }

        public Product Product { get; set; }

        // Navigation to Order
        public int OrderId { get; set; }

        public Order Order { get; set; }

        // Optional: Computed SubTotal
        [Column(TypeName = "decimal(18,2)")]
        public decimal SubTotal => Quantity * UnitPrice - Discount;
    }
}
