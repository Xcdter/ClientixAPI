using System.Diagnostics.Metrics;

namespace ClientixAPI.Models
{
    public class Client
    {
        public Guid Id { get; set; }
        public string INN { get; set; }
        public string Name { get; set; }
        public ClientType Type { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<Founder> Founders { get; set; }
    }

    public enum ClientType
    {
        LegalEntity,
        IndividualEntrepreneur
    }

}
