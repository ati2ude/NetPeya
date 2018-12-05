using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Wallet.Entities
{
    public class Currency : BaseEntity
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        [StringLength(3, MinimumLength = 1)]
        public string Symbol { get; set; }
        [Required]
        [StringLength(4, MinimumLength = 2)]
        public string Code { get; set; }
        [Required]
        public bool? AddOnRegistration { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
