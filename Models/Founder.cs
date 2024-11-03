namespace ClientixAPI.Models
{
    public class Founder
    {
        public Guid Id { get; set; }
        public string INN { get; set; }
        public string FullName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public Guid ClientId { get; set; }
        public Client Client { get; set; }
    }
}
