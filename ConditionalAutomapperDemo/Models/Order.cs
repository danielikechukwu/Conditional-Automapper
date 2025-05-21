
using System.ComponentModel.DataAnnotations.Schema;

namespace ConditionalAutomapperDemo.Models
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public bool IsShipped { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ShippingCost { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal OrderTotal { get; set; }

        // Relationship
        public int CustomerId { get; set; }

        public Customer Customer { get; set; } = default!;

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
