using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Domain.Wallet.Entities
{
    public class PaymentMethod
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Icon { get; set; }
        [Required]
        [Range(0.01, 100)]
        public decimal? ExternalCharges { get; set; }
        [Required]
        [Range(0.01, 100)]
        public decimal? InternalCharges { get; set; }
        public bool? AllowDeposit { get; set; }
        public bool? AllowTransfer { get; set; }
        public bool? AllowWithdrawal { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
