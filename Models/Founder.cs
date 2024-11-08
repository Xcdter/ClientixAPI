using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ClientixAPI.Models
{
    public class Founder
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "ИНН учредителя обязателен")]
        public string INN { get; set; }

        [Required(ErrorMessage = "ФИО учредителя обязательно")]
        [StringLength(150, ErrorMessage = "ФИО не должно превышать 150 символов")]
        public string FullName { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateAdded { get; set; } = DateTime.UtcNow;

        [DataType(DataType.DateTime)]
        public DateTime DateUpdated { get; set; } = DateTime.UtcNow;

        // Внешний ключ для связи с клиентом
        //[Required]
        public int ClientId { get; set; }

        [JsonIgnore]
        public Client Client { get; set; }
    }
}
