using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Wallet.Entities
{
    public class SavedCard : BaseEntity
    {
        public int ID { get; set; }
        [Required]
        public int? UserID { get; set; }
        public string CardType { get; set; }
        [Required]
        [StringLength(16, MinimumLength = 12)]
        public string MaskedNumber { get; set; }
        [Required]
        public string ExpiryDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
