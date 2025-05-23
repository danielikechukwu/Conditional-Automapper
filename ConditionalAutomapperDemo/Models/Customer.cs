namespace ConditionalAutomapperDemo.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }

        // Navigation
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
