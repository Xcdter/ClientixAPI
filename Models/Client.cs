using System.Diagnostics.Metrics;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClientixAPI.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "ИНН обязателен")]
        [RegularExpression(@"^[0-9]{10}$|^[0-9]{12}$", ErrorMessage = "ИНН должен содержать 10 или 12 цифр")]
        public string INN { get; set; }

        [Required(ErrorMessage = "Наименование обязательно")]
        [StringLength(200, ErrorMessage = "Наименование не должно превышать 200 символов")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Тип клиента обязателен")]
        public ClientType Type { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateAdded { get; set; } = DateTime.UtcNow;

        [DataType(DataType.DateTime)]
        public DateTime DateUpdated { get; set; } = DateTime.UtcNow;

        public List<Founder> Founders { get; set; } = new List<Founder>();

        // Валидация на уровне модели для проверки типа клиента
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Type == ClientType.LegalEntity && Founders.Count == 0)
            {
                yield return new ValidationResult("Юридическое лицо должно иметь хотя бы одного учредителя",
                    new[] { nameof(Founders) });
            }

            if (Type == ClientType.IndividualEntrepreneur && Founders.Count > 0)
            {
                yield return new ValidationResult("ИП не может иметь учредителей",
                    new[] { nameof(Founders) });
            }
        }
    }

    public enum ClientType
    {
        LegalEntity,
        IndividualEntrepreneur
    }

}
