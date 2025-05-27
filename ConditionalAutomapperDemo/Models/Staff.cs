namespace ConditionalAutomapperDemo.Models
{
    public class Staff
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string? Address { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
