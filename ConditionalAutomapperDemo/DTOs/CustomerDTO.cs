namespace ConditionalAutomapperDemo.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        // Possibly we include the Orders for demonstration
        public List<OrderDTO> Orders { get; set; } = new();
    }
}
